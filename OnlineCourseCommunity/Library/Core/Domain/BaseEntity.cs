using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineCourseCommunity.Library.Core.Domain
{
    public abstract class BaseEntity
    {
        [Key]
        [Required]
        public string Id { get; set; }
        public DateTime CreateOnDate { get; set; }
        public DateTime UpdateOnDate { get; set; }
        public bool IsDelete { get; set; }
        protected BaseEntity()
        {
            IsDelete = false;
            Id = Guid.NewGuid().ToString();
            CreateOnDate = DateTime.Now;
            UpdateOnDate = DateTime.Now;
        }
    }
}