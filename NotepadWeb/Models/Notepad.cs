using System.ComponentModel.DataAnnotations;

namespace NotepadWeb.Models
{
    public class Notepad
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
