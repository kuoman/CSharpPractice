using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeKatas
{
    class Refactor
    {
        private static void GetNetwork(ref string planCat, ref bool isS084, ref string planNetworkSet,
                                    ref string networkId, ref string classId, ref string planId, ref int groupKey)
        {

            NetworkSetRequest req = new NetworkSetRequest { ClassIdentifier = classId, ClassPlanIdentifier = planId, GroupKey = groupKey };

            // Get network id set
            NetworksClient nsClient = new NetworksClient();

            NetworkSetResponse response = new NetworkSetResponse();

            try
            {
                // Make the networks call
                response = nsClient.GetNetworkSet(req);

                // Close the channelw
                nsClient.Close();
            }
            catch (Exception ex) //System.ServiceModel.CommunicationException)
            {
                Log.Error(ex, $"Failed to get data from Networks.svc with req.ClassIdentifier = {req.ClassIdentifier}, req.ClassPlanIdentifier = {req.ClassPlanIdentifier}, req.GroupKey = {req.GroupKey}", req);
                nsClient.Abort();
            }

            var filtered = response.NetworkSet.Where(x =>
                   ((x.EffectiveDate <= DateTime.Today) && (x.TerminationDate >= DateTime.Today)) && (x.PlanEffectiveDate <= DateTime.Today) && (x.PlanTerminationDate >= DateTime.Today) && (x.CardStock != "NONE"));

            foreach (var n in filtered)
            {
                if (n.NetworkStatus.Contains("I") || ((n.NetworkStatus.Contains("P") && n.Id.Contains("A00005") && (n.Prefix.Contains("S065") || n.Prefix.Contains("S069")))))
                {
                    if (!planNetworkSet.Contains(n.Id.Trim()))
                    {
                        if ((n.Id.Contains("C00073") || n.Id.Contains("W00020")) && IsAcoPrefix(n.Prefix))
                            planNetworkSet += "";

                        else if ((n.Id.Contains("C00073") || n.Id.Contains("W00019")) && IsAcoPrime(n.Prefix))
                            planNetworkSet += "";

                        else if (n.Id.Contains("W00019") && IsVmPrime(n.Prefix))
                            planNetworkSet += "";

                        else if (n.Id.Contains("W00020") && IsVmAco(n.Prefix))
                            planNetworkSet += "";
                        else
                        {
                            planNetworkSet += n.Id.Trim() + ",";
                        }
                    }
                }

                if (!planCat.Contains(n.PlanCat.Trim()))
                    planCat += n.PlanCat.Trim() + ",";
            }
        }

        private static bool IsAcoPrefix(string networkPrefix)
        {
            switch (networkPrefix.ToUpper())
            {
                case "S111":
                case "S112":
                case "S113":
                case "S114":
                case "S115":
                case "S116":
                case "S117":
                case "S118":
                case "S140":
                case "S141":
                    return true;
            }

            return false;
        }
        private static bool IsAcoPrime(string acoPrime)
        {
            switch (acoPrime.ToUpper())
            {
                case "S131":
                case "S132":
                case "S133":
                case "S134":
                case "S142":
                    return true;
            }

            return false;
        }
        private static bool IsVmPrime(string vmPrime)
        {
            switch (vmPrime.ToUpper())
            {
                case "S135":
                    return true;
            }
            return false;

        }
        private static bool IsVmAco(string vmAco)
        {
            switch (vmAco.ToUpper())
            {
                case "S120":
                case "S121":
                    return true;
            }
            return false;

        }

    }

    internal static class Log
    {
        public static void Error(Exception exception, string s, NetworkSetRequest req)
        {
            throw new NotImplementedException();
        }
    }

    internal class NetworkSetResponse
    {
        public List<NetworkSet> NetworkSet { get; set; }
    }

    internal class NetworkSet
    {
        public DateTime EffectiveDate { get; set; }
        public DateTime TerminationDate { get; set; }
        public DateTime PlanEffectiveDate { get; set; }
        public DateTime PlanTerminationDate { get; set; }
        public string CardStock { get; set; }
        public string Prefix { get; set; }
        public string Id { get; set; }
        public string NetworkStatus { get; set; }
        public string PlanCat { get; set; }
    }

    internal class NetworksClient
    {
        public NetworkSetResponse GetNetworkSet(NetworkSetRequest req)
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Abort()
        {
            throw new NotImplementedException();
        }
    }

    internal class NetworkSetRequest
    {
        public string ClassIdentifier { get; set; }
        public string ClassPlanIdentifier { get; set; }
        public int GroupKey { get; set; }
    }
}
