using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SrednjeSkoleApp.Web.ViewModels
{
    public class LoginVM
    {
        [StringLength(100, ErrorMessage = "Korisničko ime mora sadržavati mininalno 3 karaktera.", MinimumLength = 3)]
        public string username { get; set; ***REMOVED***
        [StringLength(100, ErrorMessage = "Password mora sadržavati mininalno 4 karaktera.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string password { get; set; ***REMOVED***
        public bool ZapamtiPassword { get; set; ***REMOVED***
***REMOVED***
***REMOVED***
