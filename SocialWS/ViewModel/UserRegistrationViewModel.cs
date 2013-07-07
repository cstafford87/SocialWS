using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace SocialWS.ViewModel
{
    public class UserRegistrationViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.UserRegistration), ErrorMessageResourceName = "UsernameRequiredValidation")]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.UserRegistration), ErrorMessageResourceName = "FirstNameRequiredValidation")]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.UserRegistration), ErrorMessageResourceName = "LastNameRequiredValidation")]
        public string LastName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.UserRegistration), ErrorMessageResourceName = "EmailAddressRequiredValidation", ErrorMessage = null)]
        [EmailAddress(ErrorMessageResourceType = typeof(Resources.UserRegistration), ErrorMessageResourceName = "EmailAddressFormatValidation", ErrorMessage = null)]
        public string EmailAddress { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.UserRegistration), ErrorMessageResourceName = "PasswordRequiredValidation")]
        public string Password { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.UserRegistration), ErrorMessageResourceName = "RegKeyRequiredValidation")]
        public string RegistrationKey { get; set; }
    }
}