using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DTS.Models
{
    public class StorageModel
    {
        public int StorageId { get; set; }

        [Display(Name = "Storage Size")]
        [Required(ErrorMessage = "Required")]
        public string StorageSize { get; set; }
        public string Error { get; set; }
        public List<StorageModel> LIST_STORAGE { get; set; }
    }
}