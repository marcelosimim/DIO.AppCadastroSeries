using System;

namespace DIO.Series
{
    public class Serie : BaseEntity
    {
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool Deleted { get; set; }

        public Serie(int id, Genre genre, string title, string description, int year)
        {
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Deleted = false;
        }

        public override string ToString()
        {
            return "Genre: " + this.Genre + Environment.NewLine +
                "Title: " + this.Title + Environment.NewLine +
                "Description: " + this.Description + Environment.NewLine +
                "Start year: " + this.Year + Environment.NewLine +
                "Deleted: " + this.Deleted + Environment.NewLine;
        }

        public int returnId()
        {
            return this.Id;
        }

        public string returnTitle()
        {
            return this.Title;
        }

        public int returnYear()
        {
            return this.Year;
        }

        public bool returnDelete()
        {
            return this.Deleted;
        }

        public void delete()
        {
            this.Deleted = true;
        }
    }
}
