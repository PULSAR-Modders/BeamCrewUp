using System;
using PulsarModLoader.Chat.Commands.CommandRouter;
using PulsarModLoader.Utilities;
using UnityEngine;

namespace BeamMeUp
{
    internal class Command : PublicCommand
    {
        public override string[] CommandAliases()
        {
            return new string[]
            {
                "beamCrewUp"
            };
        }
        public override string Description()
        {
            return "Teleport a crew member back to the ship using ID or name.";
        }
        public override void Execute(string arguments, int SenderID)
        {
            if (PhotonNetwork.isMasterClient && PLServer.Instance.GetPlayerFromPlayerID(SenderID).GetClassID() == 0)
            {
                int inPlayerID;
                if (int.TryParse(arguments.Split(new char[] { ' ' })[0], out inPlayerID))
                {
                    PLPlayer plplayer = PLServer.Instance.GetPlayerFromPlayerID(inPlayerID);
                    int subHubID = PLNetworkManager.Instance.LocalPlayer.StartingShip.MyTLI.SubHubID;
                    if (plplayer.TeamID == 0)
                    {
                        if (plplayer.SubHubID == subHubID)
                        {
                            Messaging.Echo(PhotonTargets.All, "[BeamCrewUp] " + " [&%~[C" + plplayer.GetClassID().ToString() + " " + plplayer.GetPlayerName(false) + " ]&%~]" + " Is already on the ship.");
                            return;
                        }
                        plplayer.photonView.RPC("NetworkTeleportToSubHub", PhotonTargets.All, new object[]
                        {
                            subHubID,
                            0
                        });
                        plplayer.photonView.RPC("NetworkTeleportToSubHub", PhotonTargets.All, new object[]
                        {
                            subHubID,
                            0
                        });
                        Messaging.Echo(PhotonTargets.All, "[BeamCrewUp] " + " [&%~[C" + plplayer.GetClassID().ToString() + " " + plplayer.GetPlayerName(false) + " ]&%~]" + " Has teleported back to the ship.");
                        return;
                    }
                    Messaging.Echo(PhotonTargets.All, "[BeamCrewUp] ID not found, please use a friendly-teammates ID.");
                }
                else
                {
                    foreach (PLPlayer plplayer in PLServer.Instance.AllPlayers)
                    {
                        if (plplayer.GetPlayerName(false).ToLower().Equals(arguments.ToLower()) && plplayer.TeamID == 0)
                        {
                            int subHubID = PLNetworkManager.Instance.LocalPlayer.StartingShip.MyTLI.SubHubID;
                            if (plplayer.SubHubID == subHubID)
                            {
                                Messaging.Echo(PhotonTargets.All, "[BeamCrewUp] " + " [&%~[C" + plplayer.GetClassID().ToString() + " " + plplayer.GetPlayerName(false) + " ]&%~]" + " Is already on the ship.");
                                return;
                            }
                            plplayer.photonView.RPC("NetworkTeleportToSubHub", PhotonTargets.All, new object[]
                            {
                            subHubID,
                            0
                            });
                            plplayer.photonView.RPC("NetworkTeleportToSubHub", PhotonTargets.All, new object[]
                            {
                            subHubID,
                            0
                            });
                            Messaging.Echo(PhotonTargets.All, "[BeamCrewUp] " + " [&%~[C" + plplayer.GetClassID().ToString() + " " + plplayer.GetPlayerName(false) + " ]&%~]" + " Has teleported back to the ship.");
                            return;
                        }
                    }
                    Messaging.Echo(PhotonTargets.All, "[BeamCrewUp] Player not found, please use their full in-game name.");
                }
            }
        }
    }
}
