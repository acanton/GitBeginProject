using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGit;
using NGit.Api;
using NGit.Transport;

namespace buildbot.ClassCollection
{
    class BuildbotClass
    {
        int result;
        string activeRepopath = @"C:\git";
        string activeURI = "git@github.com:gbibek/test_buildbot.git";
        IndexDiff indexDiff;


        public BuildbotClass()
        {
            result = 1;
            /*var clone = Git.CloneRepository()
                .SetDirectory(activeRepopath)
                .SetURI(activeURI);
           
            var repo = clone.Call();*/
        }
        public void Merge()
        {

        }


        public void print_result()
        {
            Console.WriteLine(result);
        }

        
        public void git_pool()
        {
            var repository = Git.Open(activeRepopath);
            int test_value = 0;
            ICollection<TrackingRefUpdate> refUpdate = null;

          
           // Console.WriteLine(repository.Status().Call().IsClean());
            repository.Pull().Call();
            while (test_value == 0 )
            {

             
               FetchResult result = repository.Fetch().Call();
               refUpdate = result.GetTrackingRefUpdates();
               test_value = refUpdate.Count();
               Console.Write(test_value);
               
            }
     
            Console.WriteLine("Something changed");
           
        }


    }
}
