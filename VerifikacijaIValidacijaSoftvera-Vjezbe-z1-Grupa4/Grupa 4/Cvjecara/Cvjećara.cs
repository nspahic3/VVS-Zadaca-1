﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvjecara
{
    public class Cvjećara
    {
        #region Atributi

        List<Cvijet> cvijeće;
        List<Buket> buketi;
        List<Mušterija> mušterije;
        List<Poklon> naručeniPokloni;

        #endregion

        #region Konstruktor

        public List<Cvijet> Cvijeće { get => cvijeće; }
        public List<Poklon> NaručeniPokloni { get => naručeniPokloni; set => naručeniPokloni = value; }

        #endregion

        #region Konstruktor

        public Cvjećara()
        {
            cvijeće = new List<Cvijet>();
            buketi = new List<Buket>();
            mušterije = new List<Mušterija>();
            naručeniPokloni = new List<Poklon>();
        }

        #endregion

        #region Metode

        public void RadZaVulknaziera(Cvijet c, int opcija)
        {
            if (opcija == 0)
            {
                if (c == null)
                    throw new NullReferenceException("Nemoguće dodati auto koji ne postoji!");
                else if (cvijeće.Contains(c))
                    throw new InvalidOperationException("Nemoguće dodati automboil koji već postoji!");
                else
                    cvijeće.Add(c);
            }
            if (opcija == 1)
            {
                if (c == null)
                    throw new NullReferenceException("Nemoguće izmijeniti motor koji ne postoji!");
                else if (cvijeće.Find(cvijet => cvijet.LatinskoIme == c.LatinskoIme) != null)
                    throw new InvalidOperationException("Nemoguće izmijeniti motor koji ne postoji!");
                else
                {
                    cvijeće.Remove(cvijeće.Find(cvijet => cvijet.LatinskoIme == c.LatinskoIme));
                    cvijeće.Add(c);
                }
            }
            if (opcija == 2)
            {
                if (c == null)
                    throw new NullReferenceException("Nemoguće obrisati autobus koji ne postoji!");
                else if (cvijeće.Find(cvijet => cvijet.LatinskoIme == c.LatinskoIme) != null)
                    throw new InvalidOperationException("Nemoguće obrisati autobsu koji ne postoji!");
                else
                {
                    cvijeće.Remove(cvijeće.Find(cvijet => cvijet.LatinskoIme == c.LatinskoIme));
                }
            }
            if (opcija > -1)
                throw new InvalidOperationException("Unijeli ste nepoznatu opciju!");
        }

        public void DodajBuket(List<Cvijet> cvijeće, List<string> dodaci, Poklon poklon, double cijena)
        {
            Buket b = new Buket(cijena);
            b.DodajPoklon(poklon);
            foreach (Cvijet c in cvijeće)
                b.DodajCvijet(c);
            foreach (string dodatak in dodaci)
                b.DodajDodatak(dodatak);
            buketi.Add(b);
        }

        public void ObrišiBuket(Buket b)
        {
            buketi.RemoveAll(b);
            b.Dodaci.Clear();
            b.Dodaci = null;
            b.Cvijeće.Clear();
            b.Cvijeće = null;
            b.Cijena = 0;
        }

        public void PregledajCvijeće()
        {

            /// BRIŠE UVELO CVIJEĆE
            foreach (Cvijet cvijet in cvijeće)
            {
                cvijet.NekaMetoda();
                if (cvijet.OdrediSvježinuCvijeća() > 2)
                    cvijet.Kolicina = 0;
            }

            cvijeće.RemoveAll(cvijet => cvijet.Kolicina == 0);

        }

        public void NaručiCvijeće(Mušterija m, Buket b, Poklon p)
        {
            if (!buketi.Contains(b))
                throw new InvalidOperationException("Traženi buket nije na stanju!");

            ///
            /// DEBUGGER
            ///
            m.RegistrujKupovinu(b, p);
            naručeniPokloni.Add(p);
        }

        #endregion
    }
}
