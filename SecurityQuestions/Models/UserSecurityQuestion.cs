using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecurityQuestions.Models
{
    public class UserSecurityQuestion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserSecurityQuestionID { get; set; }
        public int UserID { get; set; }
        public int SecurityQuestionID { get; set; }
        public string SecurityQuestionAnswer { get; set; }
    }
}
