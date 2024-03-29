﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace EntityLayer.EntityLibrary
{
    public partial class SystemUsers
    {
        public SystemUsers()
        {
            BlogContentsCreatedBy = new HashSet<BlogContents>();
            BlogContentsDeletedBy = new HashSet<BlogContents>();
            Blogs = new HashSet<Blogs>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsAdmin { get; set; }
        public byte? RowStatusId { get; set; }

        public virtual ICollection<BlogContents> BlogContentsCreatedBy { get; set; }
        public virtual ICollection<BlogContents> BlogContentsDeletedBy { get; set; }
        public virtual ICollection<Blogs> Blogs { get; set; }
    }
}