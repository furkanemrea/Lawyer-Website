﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace EntityLayer.EntityLibrary
{
    public partial class Bulletins
    {
        public long Id { get; set; }
        public DateTime? DisplayDateTime { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Contents { get; set; }
        public byte? RowStatusId { get; set; }
        public long? CreatedById { get; set; }
    }
}