﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SimpleWarehouse.Constants;

namespace SimpleWarehouse.Model
{
    [Table("revisions")]
    public class Revision
    {
        public Revision()
        {
            RevisionDate = DateTime.Now;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [Index(IsUnique = true)]
        public int Id { get; set; }

        [Column("expenses")] public double Expenses { get; set; }

        [Column("revenue")] public double Revenue { get; set; }

        [Column("actual_revenue")] public double ActualRevenue { get; set; }

        [Required] [Column("start_date")] public DateTime StartDate { get; set; }

        [Column("revision_date")] public DateTime RevisionDate { get; set; }

        public override string ToString()
        {
            return $"Приходи: {Revenue:F2} \r\n" +
                   $"Разходи: {Expenses:F2}\r\n" +
                   $"Изчислени приходи (ревизия): {ActualRevenue:F2}\r\n" +
                   $"Начална дата: {StartDate.ToString(Config.DateTimeFormat)}\r\n" +
                   $"Дата на ревизия: {RevisionDate.ToString(Config.DateTimeFormat)}\r\n";
        }
    }
}