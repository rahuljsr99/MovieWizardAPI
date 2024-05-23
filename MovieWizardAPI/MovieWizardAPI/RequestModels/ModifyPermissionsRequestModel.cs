using System;
using System.ComponentModel.DataAnnotations;

namespace MovieWizardAPI.RequestModels
{
    public class ModifyPermissionsRequestModel
    {
        public int currentUserId { get; set; }
        public bool IsAdmin { get; set; }
        public string permissionChangeRequestType { get; set; }
        public bool permissionChangeRequestValue { get; set; }
        public int changeRequestUserId { get; set; }
    }
}
