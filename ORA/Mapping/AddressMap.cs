using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ORA.Models;
using ORA_Data.DAL;
using ORA_Data.Model;

namespace ORA.Mapping
{
    public class AddressMap
    {
        private static readonly AddressDAL addressDO = new AddressDAL();

        //public static void CreateAddress(AddressVM address)
        //{
        //    addressDO.CreateAddress(Mapper.Map<EmployeeDM>(address));
        //}

        //public static AddressVM GetAddressById(int addressId)
        //{
        //    return Mapper.Map<AddressVM>(addressDO.ReadAddressById(addressId));
        //}

        //public static void UpdateAddress(AddressVM address)
        //{
        //    addressDO.UpdateAddress(Mapper.Map<EmployeeDM>(address));
        //}

        //public static void DeleteAddress(AddressVM address)
        //{
        //    addressDO.DeleteAddress(Mapper.Map<EmployeeDM>(address));
        //}
    }
}