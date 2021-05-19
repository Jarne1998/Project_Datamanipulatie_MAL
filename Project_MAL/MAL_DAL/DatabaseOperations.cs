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
                    .Include(x => x.name)
                    .OrderBy(x => x.name)
                    .ToList();
            }
        }

        public static List<Anime> OphalenAnime()
        {
            using (Project_MALEntities project_MALEntities = new Project_MALEntities())
            {
                return project_MALEntities.Anime
                    .OrderBy(x => x.name)
                    .ToList();
            }
        }

        public static List<Studio> OphalenStudio()
        {
            using (Project_MALEntities project_MALEntities = new Project_MALEntities()) 
            {
                return project_MALEntities.Studio
                    .OrderBy(x => x.name)
                    .ToList();
            }
        }

        public static List<Collection> OphalenCollectie()
        {
            using (Project_MALEntities project_MALEntities = new Project_MALEntities())
            {
                return project_MALEntities.Collection
                    .OrderBy(x => x.name)
                    .ToList();
            }
        }

        // Kan geen gegevens weergeven
        public static List<User> OphalenUsers()
        {
            using (Project_MALEntities project_MALEntities = new Project_MALEntities())
            {
                return project_MALEntities.User
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
    }
}
