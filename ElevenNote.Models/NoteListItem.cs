using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
    public class NoteListItem
    {
        public int NoteId { get; set; }
        public string Title { get; set; }

        [Display(Name="Created")]   // These are the properties that will show up in the view.  You can add data annotations to these 
                                    // properties.  For example, to change the display fo CreatedUtc: [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}

// Models throughout our application for scaffolding code, creating objects properly at the right time and in the right way
// and matching objects that are passed in from the view to properly reflect what they should be shaped like in the database.  

// The NoteListItem Model will handle the task of collecting property data for a list of notes.  When a user enters information, 
// we will want them to enter specific data.  When we show information, we will want to show specific data in specific views.  
