using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Shared;

namespace Domain.Exceptions
{
    public static class DomainErrors
    {
        public static class Gathering
        {

            public static readonly Error GatheringNotFound = new Error(
                "Gathering.GatheringNotFound",
                "Gathering not found.");

            public static readonly Error GatheringAlreadyPassed = new Error(
                "Gathering.GatheringAlreadyExists",
                "Gathering already exists.");

            public static readonly Error InvitingError = new Error(
                "Gathering.InvitingError",
                "Inviting error.");

        }




    }
}
