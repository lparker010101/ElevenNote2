﻿using ElevenNote.Models;
using ElevenNote.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElevenNote.WebAPI2.Controllers
{
    [Authorize]
    public class NoteController : ApiController
    { 
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            NoteService noteService = CreateNoteService();
            var notes = noteService.GetNotes();
            return Ok(notes);
        }

        [HttpPost]
        public IHttpActionResult Post(NoteCreate note)
        {
            if (!ModelState.IsValid) // A ModelState represents a collection of name and value pairs that were submitted to the server during a POST.
                return BadRequest(ModelState); 

            var service = CreateNoteService();

            if (!service.CreateNote(note))
                return InternalServerError();

            return Ok();
        }

        private NoteService CreateNoteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var noteService = new NoteService(userId);
            return noteService;
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            NoteService noteService = CreateNoteService();
            var note = noteService.GetNoteById(id);
            return Ok(note);
        }

        [HttpPut] // Put means to update.
        public IHttpActionResult Put(NoteEdit note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateNoteService();

            if (!service.UpdateNote(note))
                return InternalServerError();

            return Ok();
        }
    }
}
