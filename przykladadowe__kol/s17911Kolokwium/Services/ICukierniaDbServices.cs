using Microsoft.AspNetCore.Mvc;
using s17911Kolokwium.DTOs;
using s17911Kolokwium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s17911Kolokwium.Services
{
    public interface ICukierniaDbServices
    {
        IActionResult GetZamowienia();
        IActionResult GetZamowienie(String imie);

        IActionResult DodajZamowienie(NoweZamowienieDto noweZamowienieDto, int idKlient);
    }
}
