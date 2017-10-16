using AutoMapper;
using ORA.Models;
using ORA_Data.DAL;
using ORA_Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ORA.Mapping;

namespace ORA.Controllers
{
    public class AddressController : Controller
    {
        
        public ActionResult CreateAddress()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAddress(AddressVM address)
        {
            AddressDAL.CreateAddress(Mapper.Map<AddressDM>(address));
            return View();
        }

        public ActionResult ReadAddress()
        {
            return View(AddressDAL.ReadAllAddress());
        }

        public ActionResult AddressDetails(int addressId)
        {
            return View(Mapper.Map<AddressVM>(AddressDAL.ReadAddressById(addressId)));
        }

        [HttpGet]
        public ActionResult UpdateAddress(int addressId)
        {
            return View(Mapper.Map<AddressVM>(AddressDAL.ReadAddressById(addressId)));
        }

        [HttpPost]
        public ActionResult UpdateAddress(AddressVM address)
        {
            AddressDAL.UpdateAddress(Mapper.Map<AddressDM>(address));
            ModelState.Clear();
            return RedirectToAction("ReadAddress");
        }

        public ActionResult DeleteAddress(int addressId)
        {
            return View(Mapper.Map<AddressVM>(AddressDAL.ReadAddressById(addressId)));
        }

        [HttpPost]
        public ActionResult DeleteAddress(AddressVM address)
        {
            AddressDAL.DeleteAddress(Mapper.Map<AddressDM>(address));
            ModelState.Clear();
            return RedirectToAction("ReadAddress");
        }
    }
}