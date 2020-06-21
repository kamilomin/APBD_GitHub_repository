using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using s17911Kolokwium.DTOs;
using s17911Kolokwium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s17911Kolokwium.Services
{
    public class EfCukierniaDbServices : ICukierniaDbServices
    {
        private readonly CukierniaContext _context;

        public EfCukierniaDbServices(CukierniaContext context)
        {
            _context = context;
        }

        public IActionResult DodajZamowienie(NoweZamowienieDto newOrderDto, int idClient)
        {
            if (newOrderDto.Wyroby.Count() == 0)
            {
                return new BadRequestObjectResult("Zamowienie musi miec conajmniej jedna pozycje");
            }

            Klient client = _context.Clients.Find(idClient);
            if (client == null)
            {
                return new NotFoundObjectResult("Nie ma klienta o takim id");
            }

            Zamowienie order = new Zamowienie
            {
                IdClient = idClient,
                IdEmployee = idClient % 2,
                AcceptanceDate = newOrderDto.DataPrzyjecia,
                Comments = newOrderDto.Uwagi
            };
            _context.Orders.Add(order);
            _context.SaveChanges();

            foreach (NoweZamowienieProduktDto newOrderItemDto in newOrderDto.Wyroby)
            {
                WyrobProdukt confectioneryProduct = _context.ConfectioneryProducts
                    .Where(p => p.Name == newOrderItemDto.Wyrob)
                    .FirstOrDefault();
                if (confectioneryProduct == null)
                {
                    return new NotFoundObjectResult("Produkt o takiej nazwie nie istnieje");
                }
                ZamowienieProdukt orderItem = new ZamowienieProdukt
                {
                    IdOrder = _context.Orders.Max(o => o.IdOrder),
                    IdConfectioneryProduct = confectioneryProduct.IdConfectioneryProduct,
                    Quantity = int.Parse(newOrderItemDto.Ilosc),
                    Comments = newOrderItemDto.Uwagi
                };
                _context.OrderItems.Add(orderItem);
            }
            _context.SaveChanges();


            return new OkObjectResult("Ok");
        }

        public IActionResult GetZamowienie(String surname)
        {
            List<OrderDto> orderDtos = new List<OrderDto>();

            var idClient = _context.Clients.Where(c => c.Surname == surname).Select(c => c.IdClient).FirstOrDefault();
            var orders = _context.Orders.Where(o => o.IdClient == idClient).ToList();

            if (orders.Count == 0)
            {
                return null;
            }

            foreach (Zamowienie o in orders)
            {
                var items = new List<OrderItemDto>();

                var confectioneryProducts = _context.OrderItems.Where(i => i.IdOrder == o.IdOrder).ToList();
                foreach (ZamowienieProdukt i in confectioneryProducts)
                {
                    var product = _context.ConfectioneryProducts.Where(p => p.IdConfectioneryProduct == i.IdConfectioneryProduct).FirstOrDefault();

                    items.Add(new OrderItemDto
                    {
                        Name = product.Name,
                        Type = product.Type,
                        Quantity = i.Quantity,
                        Comments = i.Comments
                    });
                }

                orderDtos.Add(new OrderDto
                {
                    IdOrder = o.IdOrder,
                    AcceptanceDate = o.AcceptanceDate,
                    RealizationDate = o.RealizationDate,
                    Comments = o.Comments,
                    OrderItems = items
                });
            };

            return new OkObjectResult(orderDtos);
        }

        public IActionResult GetZamowienia()
        {
            List<OrderDto> orderDtos = new List<OrderDto>();

            var orders = _context.Orders.ToList();
            foreach (Zamowienie o in orders)
            {
                var items = new List<OrderItemDto>();

                var confectioneryProducts = _context.OrderItems.Where(i => i.IdOrder == o.IdOrder).ToList();
                foreach (ZamowienieProdukt i in confectioneryProducts)
                {
                    var product = _context.ConfectioneryProducts.Where(p => p.IdConfectioneryProduct == i.IdConfectioneryProduct).FirstOrDefault();

                    items.Add(new OrderItemDto
                    {
                        Name = product.Name,
                        Type = product.Type,
                        Quantity = i.Quantity,
                        Comments = i.Comments
                    });
                }

                orderDtos.Add(new OrderDto
                {
                    IdOrder = o.IdOrder,
                    AcceptanceDate = o.AcceptanceDate,
                    RealizationDate = o.RealizationDate,
                    Comments = o.Comments,
                    OrderItems = items
                });
            };

            return new OkObjectResult(orderDtos);
        }
    }
}
