using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MAL_DAL
{
    public static class DatabaseOperations
    {
        public static List<Anime> OphalenAnimeByName(string name)
        {
            using (Project_MALEntities project_MALEntities = new Project_MALEntities())
            {
                return project_MALEntities.Anime
                    .Include(x => x.AnimeCollection)
                    .OrderBy(x => x.name)
                    .ToList();
            }
        }

        public static List<Anime> OphalenAnimes()
        {
            using (Project_MALEntities project_MALEntities = new Project_MALEntities())
            {
                return project_MALEntities.Anime
                    .Include(x => x.AnimeCollection)
                    .Include(x => x.Studios)
                    .OrderBy(x => x.name)
                    .ToList();
            }
        }

        public static List<Studio> OphalenStudio()
        {
            using (Project_MALEntities project_MALEntities = new Project_MALEntities()) 
            {
                return project_MALEntities.Studio
                    .Include(x => x.Anime)
                    .OrderBy(x => x.name)
                    .ToList();
            }
        }

        public static List<Collection> OphalenCollectie()
        {
            using (Project_MALEntities project_MALEntities = new Project_MALEntities())
            {
                return project_MALEntities.Collection
                    .Include(x => x.AnimeCollection.Select(sub => sub.Animes))
                    //.Where(x => x.userId == collection_Id)
                    .OrderBy(x => x.name)
                    .ToList();
            }
        }

        public static Anime OphalenAnimesViaId()
        {
            using (Project_MALEntities project_MALEntities = new Project_MALEntities())
            {
                return project_MALEntities.Anime
                    .Include(x => x.AnimeCollection)
                    .Where(x => x.animeId == Helper.animeId)
                    .OrderBy(x => x.name)
                    .SingleOrDefault();
            }
        }

        // Kan geen gegevens weergeven
        public static List<User> OphalenUsers()
        {
            using (Project_MALEntities project_MALEntities = new Project_MALEntities())
            {
                return project_MALEntities.User
                    .Include(x => x.Collection.Select(sub => sub.AnimeCollection.Select(sub2 => sub2.Animes)))
                    .OrderBy(x => x.name)
                    .ToList();
            }
        }

        public static List<User> OphalenUsersViaId(int user_Id)
        {
            using (Project_MALEntities project_MALEntities = new Project_MALEntities())
            {
                return project_MALEntities.User
                    .Where(x => x.userId == user_Id)
                    .OrderBy(x => x.name)
                    .ToList();
            }
        }

        public static int AanpassenNaamLijst(Collection collection)
        {
            try
            {
                using (Project_MALEntities project_MALEntities = new Project_MALEntities())
                {
                    project_MALEntities.Entry(collection).State = EntityState.Modified;
                    return project_MALEntities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.Foutloggen(ex);
                return 0;
            }
        }

        public static int VerwijderenLijst(Collection collection)
        {
            try
            {
                using (Project_MALEntities project_MALEntities = new Project_MALEntities())
                {
                    project_MALEntities.Entry(collection).State = EntityState.Deleted;
                    return project_MALEntities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.Foutloggen(ex);
                return 0;
            }
        }

        public static int ToevoegenLijst(Collection collection)
        {
            try
            {
                using (Project_MALEntities project_MALEntities = new Project_MALEntities())
                {
                    project_MALEntities.Collection.Add(collection);
                    return project_MALEntities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.Foutloggen(ex);
                return 0;
            }
        }
    }
}
