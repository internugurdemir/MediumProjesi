using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectMedium.Models.DataAccess.Entitites;

namespace ProjectMedium.Models.DataAccess.Mapping
{
    public class NoteMapping:IEntityTypeConfiguration<Note>
    {

        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.ToTable("Notes");
            builder.Property(c => c.NoteID).ValueGeneratedOnAdd().UseIdentityColumn(1, 1);
            builder.Property(c => c.Title).HasMaxLength(100);
            builder.HasKey(a => a.NoteID);
            builder.HasData(
            new Note()
            {
                NoteID = 1,
                Title = "First Note",
                IsActive = true,
                Content = "In European music theory, most countries use the solfège naming convention do–re–mi–fa–sol–la–si, including for instance Italy, Portugal, Spain, France, Romania, most Latin American countries, Greece, Albania, Bulgaria, Turkey, Russia, Arabic-speaking and Persian-speaking countries. However, in English- and Dutch-speaking regions, pitch classes are typically represented by the first seven letters of the Latin alphabet (A, B, C, D, E, F and G). A few European countries, including Germany, adopt an almost identical notation, in which H substitutes for B (see below for details). Byzantium used the names Pa–Vu–Ga–Di–Ke–Zo–Ni (Πα–Βου–Γα–Δι–Κε–Ζω–Νη).",
                CreatedDate = DateTime.Now,
                UserID = 454
            });


        }
    }
}
