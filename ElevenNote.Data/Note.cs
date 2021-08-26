using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Data
{
    public class Note
        {
            [Key] //These are called annotations.  This is the primary key.  This attribute specifies the property that uniquely identifies an entity.
            public int NoteId { get; set; }

            [Required] // Required attribute ensures the user does not enter a null value.
            [Range(1, 5, ErrorMessage ="please choose a number between 1 and 5")]  // The range attribute ensures the user provides a value within the specified range.
            [MaxLength(100, ErrorMessage = "There are too many characters in this field.")] // Attributes such as [MaxLength] limit the amount of characters users can provide.
            public Guid OwnerId { get; set; }  // Guid is a type that allows us to create unique, near impossible to replicate (like 1 in 1 trillion chance) IDs for our users or items for our users.
                                               // Guid - Globally Unique IDentifier (32 digit hexadecimals grouped in chunks 8-4-4-12.
                                               // Guid - good for security but bad for debugging b/c they are hard to access.
            [Required]
            public string Title { get; set; }

            [Required]
            [Display(Name = "Your Note")] // Use the [Display] or [Display(Name)] attribute to change the name the user is shown for a property.
            public string Content { get; set; }

            [Required]
            public DateTimeOffset CreatedUtc { get; set; }
            public DateTimeOffset? ModifiedUtc { get; set; }

            [ForeignKey(nameof(Category))]
            public Category Category { get; set; }

        }
    }





