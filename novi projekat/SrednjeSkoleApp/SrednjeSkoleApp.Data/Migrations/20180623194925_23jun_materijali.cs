﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SrednjeSkoleApp.Data.Migrations
{
    public partial class _23jun_materijali : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Predmet",
                columns: table => new
                {
                    PredmetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: false),
                    Oznaka = table.Column<string>(nullable: false)
            ***REMOVED***,
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predmet", x => x.PredmetId);
            ***REMOVED***);

            migrationBuilder.CreateTable(
                name: "SkolskaGodina",
                columns: table => new
                {
                    SkolskaGodinaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
            ***REMOVED***,
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkolskaGodina", x => x.SkolskaGodinaId);
            ***REMOVED***);

            migrationBuilder.CreateTable(
                name: "Uloge",
                columns: table => new
                {
                    UlogaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Administrator = table.Column<bool>(nullable: false),
                    Nastavnik = table.Column<bool>(nullable: false),
                    Naziv = table.Column<string>(nullable: true),
                    Roditelj = table.Column<bool>(nullable: false),
                    SuperAdministrator = table.Column<bool>(nullable: false),
                    Ucenik = table.Column<bool>(nullable: false)
            ***REMOVED***,
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uloge", x => x.UlogaId);
            ***REMOVED***);

            migrationBuilder.CreateTable(
                name: "Smjerovi",
                columns: table => new
                {
                    SmjerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    SkolskaGodinaId = table.Column<int>(nullable: false)
            ***REMOVED***,
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smjerovi", x => x.SmjerId);
                    table.ForeignKey(
                        name: "FK_Smjerovi_SkolskaGodina_SkolskaGodinaId",
                        column: x => x.SkolskaGodinaId,
                        principalTable: "SkolskaGodina",
                        principalColumn: "SkolskaGodinaId",
                        onDelete: ReferentialAction.Cascade);
            ***REMOVED***);

            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Aktivan = table.Column<bool>(nullable: false),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Ime = table.Column<string>(nullable: false),
                    JMBG = table.Column<string>(maxLength: 13, nullable: true),
                    KorisnickoIme = table.Column<string>(nullable: false),
                    LozinkaHash = table.Column<string>(nullable: true),
                    LozinkaSalt = table.Column<string>(nullable: true),
                    MjestoRodjenja = table.Column<string>(nullable: true),
                    Prebivaliste = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: false),
                    Spol = table.Column<string>(nullable: true),
                    DatumIzboraUZvanje = table.Column<DateTime>(nullable: true),
                    GodinaZaposlenja = table.Column<int>(nullable: true),
                    NaucnaOblast = table.Column<string>(nullable: true),
                    Zvanje = table.Column<string>(nullable: true),
                    GodinaUpisa = table.Column<int>(nullable: true),
                    ImeRoditelja = table.Column<string>(nullable: true),
                    NazivOsnovneSkole = table.Column<string>(nullable: true),
                    ProsjekOcjenaOsnovnaSkola = table.Column<double>(nullable: true),
                    SmjerId = table.Column<int>(nullable: true)
            ***REMOVED***,
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Korisnici_Smjerovi_SmjerId",
                        column: x => x.SmjerId,
                        principalTable: "Smjerovi",
                        principalColumn: "SmjerId",
                        onDelete: ReferentialAction.Cascade);
            ***REMOVED***);

            migrationBuilder.CreateTable(
                name: "SmjerPredmet",
                columns: table => new
                {
                    SmjerPredmetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrojCasova = table.Column<int>(nullable: false),
                    PredmetId = table.Column<int>(nullable: false),
                    SmjerId = table.Column<int>(nullable: false)
            ***REMOVED***,
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmjerPredmet", x => x.SmjerPredmetId);
                    table.ForeignKey(
                        name: "FK_SmjerPredmet_Predmet_PredmetId",
                        column: x => x.PredmetId,
                        principalTable: "Predmet",
                        principalColumn: "PredmetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SmjerPredmet_Smjerovi_SmjerId",
                        column: x => x.SmjerId,
                        principalTable: "Smjerovi",
                        principalColumn: "SmjerId",
                        onDelete: ReferentialAction.Cascade);
            ***REMOVED***);

            migrationBuilder.CreateTable(
                name: "AutorizacijskiToken",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IpAdresa = table.Column<string>(nullable: true),
                    KorisnikId = table.Column<int>(nullable: false),
                    Vrijednost = table.Column<string>(nullable: true),
                    VrijemeEvidentiranja = table.Column<DateTime>(nullable: false)
            ***REMOVED***,
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorizacijskiToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutorizacijskiToken_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
            ***REMOVED***);

            migrationBuilder.CreateTable(
                name: "Casovi",
                columns: table => new
                {
                    CasId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    Naslov = table.Column<string>(nullable: true),
                    NastavnikId = table.Column<int>(nullable: false),
                    Opis = table.Column<string>(nullable: true)
            ***REMOVED***,
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casovi", x => x.CasId);
                    table.ForeignKey(
                        name: "FK_Casovi_Korisnici_NastavnikId",
                        column: x => x.NastavnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
            ***REMOVED***);

            migrationBuilder.CreateTable(
                name: "KorisniciUloge",
                columns: table => new
                {
                    KorisniciUlogeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KorisnikID = table.Column<int>(nullable: false),
                    UlogaID = table.Column<int>(nullable: false)
            ***REMOVED***,
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisniciUloge", x => x.KorisniciUlogeId);
                    table.ForeignKey(
                        name: "FK_KorisniciUloge_Korisnici_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KorisniciUloge_Uloge_UlogaID",
                        column: x => x.UlogaID,
                        principalTable: "Uloge",
                        principalColumn: "UlogaId",
                        onDelete: ReferentialAction.Cascade);
            ***REMOVED***);

            migrationBuilder.CreateTable(
                name: "KorisnikKontakt",
                columns: table => new
                {
                    KorisnikKontaktId = table.Column<int>(nullable: false),
                    Adresa = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Grad = table.Column<string>(nullable: true),
                    Opstina = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true)
            ***REMOVED***,
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnikKontakt", x => x.KorisnikKontaktId);
                    table.ForeignKey(
                        name: "FK_KorisnikKontakt_Korisnici_KorisnikKontaktId",
                        column: x => x.KorisnikKontaktId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
            ***REMOVED***);

            migrationBuilder.CreateTable(
                name: "Materijali",
                columns: table => new
                {
                    MaterijalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    NastavnikId = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(nullable: true),
                    PredmetId = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: true)
            ***REMOVED***,
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materijali", x => x.MaterijalId);
                    table.ForeignKey(
                        name: "FK_Materijali_Korisnici_NastavnikId",
                        column: x => x.NastavnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Materijali_Predmet_PredmetId",
                        column: x => x.PredmetId,
                        principalTable: "Predmet",
                        principalColumn: "PredmetId",
                        onDelete: ReferentialAction.Restrict);
            ***REMOVED***);

            migrationBuilder.CreateTable(
                name: "Obavijesti",
                columns: table => new
                {
                    ObavijestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    KorisnikId = table.Column<int>(nullable: false),
                    Naslov = table.Column<string>(nullable: true),
                    Tekst = table.Column<string>(nullable: true)
            ***REMOVED***,
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obavijesti", x => x.ObavijestId);
                    table.ForeignKey(
                        name: "FK_Obavijesti_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
            ***REMOVED***);

            migrationBuilder.CreateTable(
                name: "Razred",
                columns: table => new
                {
                    RazredId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Odjeljenje = table.Column<string>(nullable: true),
                    Oznaka = table.Column<string>(nullable: true),
                    RazredBrojcano = table.Column<int>(nullable: false),
                    RazrednikId = table.Column<int>(nullable: false),
                    SkolskaGodinaId = table.Column<int>(nullable: false),
                    SmjerId = table.Column<int>(nullable: false)
            ***REMOVED***,
                constraints: table =>
                {
                    table.PrimaryKey("PK_Razred", x => x.RazredId);
                    table.ForeignKey(
                        name: "FK_Razred_Korisnici_RazrednikId",
                        column: x => x.RazrednikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Razred_SkolskaGodina_SkolskaGodinaId",
                        column: x => x.SkolskaGodinaId,
                        principalTable: "SkolskaGodina",
                        principalColumn: "SkolskaGodinaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Razred_Smjerovi_SmjerId",
                        column: x => x.SmjerId,
                        principalTable: "Smjerovi",
                        principalColumn: "SmjerId",
                        onDelete: ReferentialAction.Restrict);
            ***REMOVED***);

            migrationBuilder.CreateTable(
                name: "Predaje",
                columns: table => new
                {
                    PredajeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NastavnikId = table.Column<int>(nullable: false),
                    SkolskaGodinaId = table.Column<int>(nullable: false),
                    SmjerPredmetId = table.Column<int>(nullable: false)
            ***REMOVED***,
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predaje", x => x.PredajeId);
                    table.ForeignKey(
                        name: "FK_Predaje_Korisnici_NastavnikId",
                        column: x => x.NastavnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Predaje_SkolskaGodina_SkolskaGodinaId",
                        column: x => x.SkolskaGodinaId,
                        principalTable: "SkolskaGodina",
                        principalColumn: "SkolskaGodinaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Predaje_SmjerPredmet_SmjerPredmetId",
                        column: x => x.SmjerPredmetId,
                        principalTable: "SmjerPredmet",
                        principalColumn: "SmjerPredmetId",
                        onDelete: ReferentialAction.Restrict);
            ***REMOVED***);

            migrationBuilder.CreateTable(
                name: "Izostanci",
                columns: table => new
                {
                    IzostanakId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CasId = table.Column<int>(nullable: false),
                    Komentar = table.Column<string>(nullable: true),
                    Razlog = table.Column<string>(nullable: true),
                    UcenikId = table.Column<int>(nullable: false)
            ***REMOVED***,
                constraints: table =>
                {
                    table.PrimaryKey("PK_Izostanci", x => x.IzostanakId);
                    table.ForeignKey(
                        name: "FK_Izostanci_Casovi_CasId",
                        column: x => x.CasId,
                        principalTable: "Casovi",
                        principalColumn: "CasId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Izostanci_Korisnici_UcenikId",
                        column: x => x.UcenikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
            ***REMOVED***);

            migrationBuilder.CreateTable(
                name: "UceniciCasovi",
                columns: table => new
                {
                    UcenikCasoviId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CasId = table.Column<int>(nullable: false),
                    UcenikId = table.Column<int>(nullable: false)
            ***REMOVED***,
                constraints: table =>
                {
                    table.PrimaryKey("PK_UceniciCasovi", x => x.UcenikCasoviId);
                    table.ForeignKey(
                        name: "FK_UceniciCasovi_Casovi_CasId",
                        column: x => x.CasId,
                        principalTable: "Casovi",
                        principalColumn: "CasId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UceniciCasovi_Korisnici_UcenikId",
                        column: x => x.UcenikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
            ***REMOVED***);

            migrationBuilder.CreateTable(
                name: "UceniciRazredi",
                columns: table => new
                {
                    UcenikRazrediId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RazredId = table.Column<int>(nullable: false),
                    RedniBroj = table.Column<int>(nullable: false),
                    SkolskaGodina = table.Column<string>(nullable: true),
                    UcenikId = table.Column<int>(nullable: false)
            ***REMOVED***,
                constraints: table =>
                {
                    table.PrimaryKey("PK_UceniciRazredi", x => x.UcenikRazrediId);
                    table.ForeignKey(
                        name: "FK_UceniciRazredi_Razred_RazredId",
                        column: x => x.RazredId,
                        principalTable: "Razred",
                        principalColumn: "RazredId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UceniciRazredi_Korisnici_UcenikId",
                        column: x => x.UcenikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
            ***REMOVED***);

            migrationBuilder.CreateTable(
                name: "UceniciOcjene",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    Napomena = table.Column<string>(nullable: true),
                    PredajeId = table.Column<int>(nullable: false),
                    TipOcjene = table.Column<string>(nullable: true),
                    UcenikId = table.Column<int>(nullable: false),
                    Vrijednost = table.Column<int>(nullable: false)
            ***REMOVED***,
                constraints: table =>
                {
                    table.PrimaryKey("PK_UceniciOcjene", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UceniciOcjene_Predaje_PredajeId",
                        column: x => x.PredajeId,
                        principalTable: "Predaje",
                        principalColumn: "PredajeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UceniciOcjene_Korisnici_UcenikId",
                        column: x => x.UcenikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
            ***REMOVED***);

            migrationBuilder.CreateIndex(
                name: "IX_AutorizacijskiToken_KorisnikId",
                table: "AutorizacijskiToken",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Casovi_NastavnikId",
                table: "Casovi",
                column: "NastavnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Izostanci_CasId",
                table: "Izostanci",
                column: "CasId");

            migrationBuilder.CreateIndex(
                name: "IX_Izostanci_UcenikId",
                table: "Izostanci",
                column: "UcenikId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_SmjerId",
                table: "Korisnici",
                column: "SmjerId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisniciUloge_KorisnikID",
                table: "KorisniciUloge",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisniciUloge_UlogaID",
                table: "KorisniciUloge",
                column: "UlogaID");

            migrationBuilder.CreateIndex(
                name: "IX_Materijali_NastavnikId",
                table: "Materijali",
                column: "NastavnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Materijali_PredmetId",
                table: "Materijali",
                column: "PredmetId");

            migrationBuilder.CreateIndex(
                name: "IX_Obavijesti_KorisnikId",
                table: "Obavijesti",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Predaje_NastavnikId",
                table: "Predaje",
                column: "NastavnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Predaje_SkolskaGodinaId",
                table: "Predaje",
                column: "SkolskaGodinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Predaje_SmjerPredmetId",
                table: "Predaje",
                column: "SmjerPredmetId");

            migrationBuilder.CreateIndex(
                name: "IX_Razred_RazrednikId",
                table: "Razred",
                column: "RazrednikId");

            migrationBuilder.CreateIndex(
                name: "IX_Razred_SkolskaGodinaId",
                table: "Razred",
                column: "SkolskaGodinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Razred_SmjerId",
                table: "Razred",
                column: "SmjerId");

            migrationBuilder.CreateIndex(
                name: "IX_Smjerovi_SkolskaGodinaId",
                table: "Smjerovi",
                column: "SkolskaGodinaId");

            migrationBuilder.CreateIndex(
                name: "IX_SmjerPredmet_PredmetId",
                table: "SmjerPredmet",
                column: "PredmetId");

            migrationBuilder.CreateIndex(
                name: "IX_SmjerPredmet_SmjerId",
                table: "SmjerPredmet",
                column: "SmjerId");

            migrationBuilder.CreateIndex(
                name: "IX_UceniciCasovi_CasId",
                table: "UceniciCasovi",
                column: "CasId");

            migrationBuilder.CreateIndex(
                name: "IX_UceniciCasovi_UcenikId",
                table: "UceniciCasovi",
                column: "UcenikId");

            migrationBuilder.CreateIndex(
                name: "IX_UceniciOcjene_PredajeId",
                table: "UceniciOcjene",
                column: "PredajeId");

            migrationBuilder.CreateIndex(
                name: "IX_UceniciOcjene_UcenikId",
                table: "UceniciOcjene",
                column: "UcenikId");

            migrationBuilder.CreateIndex(
                name: "IX_UceniciRazredi_RazredId",
                table: "UceniciRazredi",
                column: "RazredId");

            migrationBuilder.CreateIndex(
                name: "IX_UceniciRazredi_UcenikId",
                table: "UceniciRazredi",
                column: "UcenikId");
    ***REMOVED***

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutorizacijskiToken");

            migrationBuilder.DropTable(
                name: "Izostanci");

            migrationBuilder.DropTable(
                name: "KorisniciUloge");

            migrationBuilder.DropTable(
                name: "KorisnikKontakt");

            migrationBuilder.DropTable(
                name: "Materijali");

            migrationBuilder.DropTable(
                name: "Obavijesti");

            migrationBuilder.DropTable(
                name: "UceniciCasovi");

            migrationBuilder.DropTable(
                name: "UceniciOcjene");

            migrationBuilder.DropTable(
                name: "UceniciRazredi");

            migrationBuilder.DropTable(
                name: "Uloge");

            migrationBuilder.DropTable(
                name: "Casovi");

            migrationBuilder.DropTable(
                name: "Predaje");

            migrationBuilder.DropTable(
                name: "Razred");

            migrationBuilder.DropTable(
                name: "SmjerPredmet");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "Predmet");

            migrationBuilder.DropTable(
                name: "Smjerovi");

            migrationBuilder.DropTable(
                name: "SkolskaGodina");
    ***REMOVED***
***REMOVED***
***REMOVED***