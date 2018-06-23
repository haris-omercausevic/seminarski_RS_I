using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SrednjeSkoleApp.Data.Migrations
{
    public partial class materijali_blobname_naziv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BlobName",
                table: "Materijali",
                nullable: true);
    ***REMOVED***

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlobName",
                table: "Materijali");
    ***REMOVED***
***REMOVED***
***REMOVED***
