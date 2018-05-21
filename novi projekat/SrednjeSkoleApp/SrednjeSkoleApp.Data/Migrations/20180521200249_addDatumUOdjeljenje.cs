using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SrednjeSkoleApp.Data.Migrations
{
    public partial class addDatumUOdjeljenje : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Datum",
                table: "Obavijesti",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
    ***REMOVED***

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Datum",
                table: "Obavijesti");
    ***REMOVED***
***REMOVED***
***REMOVED***
