using System;
using System.Collections.Generic;
using System.Data.Entity;
using Domain;
using Domain.PK;


namespace DAL
{
    //    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DataBaseContext>
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            var autoDetectChangesEnabled = context.Configuration.AutoDetectChangesEnabled;
            // much-much faster for bulk inserts!!!!
            context.Configuration.AutoDetectChangesEnabled = false;


            SeedTypes(context);

            // restore state
            context.Configuration.AutoDetectChangesEnabled = autoDetectChangesEnabled;

            base.Seed(context);
        }

        private void SeedTypes(DatabaseContext context)
        {
            var question = new Question()
            {
                CreationDate = DateTime.Now,
                Title = "Uusim küsimus",
                Description = "Mis küll selle küsimusega võiks mõelda?",
                Public = true
            };
            context.Questions.Add(question);
            context.SaveChanges();

            var answer  = new Answer()
            {
                Question = question,
                CreationDate = DateTime.Now,
                Title = "Uusim"
            };
            var answer2 = new Answer()
            {
                Question = question,
                CreationDate = DateTime.Now,
                Title = "Vanim"
            };
            context.Answers.Add(answer);
            context.SaveChanges();
            context.Answers.Add(answer2);
            context.SaveChanges();


            var blog = new Blog()
            {
                Title = "Tiitel",
                Body = "pikkteksttegelteiole",
            };

            context.Blogs.Add(blog);
            context.SaveChanges();

            var comment = new Comment()
            {
                Blog = blog,
                User= "Peeter Pakiraam",
                Body = "Sitt blogi sul"
            };

            context.Comments.Add(comment);
            context.SaveChanges();

            var comment2 = new Comment()
            {
                Blog = blog,
                Body = "Meie oleme anan[[msed , djontaplikesiondesign"
            };

            context.Comments.Add(comment2);
            context.SaveChanges();

            //    public int CommentId { get; set; }
            //[MaxLength(100)]
            //public string User { get; set; } = "Anonymous";
            //[MaxLength(3000), MinLength(1)]
            //public string Body { get; set; }
            //public int BlogId { get; set; }
            //public virtual Blog Blog { get; set; }

        }

    }
}