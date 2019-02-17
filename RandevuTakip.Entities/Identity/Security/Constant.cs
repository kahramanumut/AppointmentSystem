namespace RandevuTakip.Entities.Identity.Security
{
    public static class Constants
    {
        public static readonly string CreateOperationName = "Create";
        public static readonly string ReadOperationName = "Read";
        public static readonly string UpdateOperationName = "Update";
        public static readonly string DeleteOperationName = "Delete";
        public static readonly string ApproveOperationName = "Approve";
        public static readonly string RejectOperationName = "Reject";

        public const string AdministratorsRole = "Administrators";
        public const string Doctor = "Doctor";
        public const string Patient = "Patient";
    }
}
