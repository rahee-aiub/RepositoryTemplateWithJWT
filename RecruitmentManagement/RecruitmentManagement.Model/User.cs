﻿namespace RecruitmentManagement.Model
{
    public class User
    {

        public string UserID { get; set; }
        public string UserName { get; set; }
        public string ShopID { get; set; }
        public string EmployeeID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string DesignationID { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool InActive { get; set; }
    }
}