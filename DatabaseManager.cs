using Game_Server.PlayerInteractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Game_Server
{
	class DatabaseManager
	{
		public static bool ReadAccountXML(string _username, string _password)
		{
			XDocument doc = XDocument.Load("D:\\GameServer\\Database\\Accounts.xml");
			IEnumerable<XElement> elements = doc.Descendants();

			List<XElement> accounts = new List<XElement>();
			foreach (XElement element in elements)
			{
				//reads through xml document and finds elements with the name Account.
				if (element.Name == "Account")
				{
					//adds the values of the accounts ID // PASSWORD // DateCreated
					XAttribute attributes = element.FirstAttribute;
					if (attributes.Value == _username)
                    {
						if(attributes.NextAttribute.Value == _password)
                        {
							return true;
                        }
                    }
				}
			}
			return false;
		}
		public static bool ReadCreateAccountXML(string _username, string _password)
		{
			XDocument doc = XDocument.Load("D:\\GameServer\\Database\\Accounts.xml");
			IEnumerable<XElement> elements = doc.Descendants();

			List<string> accounts = new List<string>();

			foreach (XElement element in elements)
			{
				//reads through xml document and finds elements with the name Account.
				if (element.Name == "Account")
				{
					//adds the values of the accounts ID // PASSWORD // DateCreated
					XAttribute attributes = element.FirstAttribute;
					accounts.Add(Convert.ToString(attributes.Value));
					while ((attributes = attributes.NextAttribute) != null)
					{
						accounts.Add(Convert.ToString(attributes.Value));
					}
				}
			}
			//LIST FOR STORED ACCOUNTS IN INCREMENTS OF 3. EX 0, 1 , 2 or 6, 7, 8.
			for (int i = 0; i < accounts.Count; i++)
			{
				if (accounts[i] == _username)
				{
					return true;
				}
			}
			return false;
		}
		public static bool ReadCreateCharacterXML(string _characterName, string _username, List<string> _characterInfo)
		{
			XDocument doc = XDocument.Load("D:\\GameServer\\Database\\Players.xml");
			IEnumerable<XElement> root = doc.Descendants();
			foreach (XElement ele in root.Elements())
			{
				if (ele.Name == "PlayerName")
				{
					XAttribute attributes = ele.FirstAttribute;
					if (attributes.Value == _characterName)
					{
						Console.WriteLine("We found a character with that name and returning false.");
						return false;
					}
				}
			}
			Console.WriteLine("We did not find a character with that name and creating character while returning true.");
			return true;
		}
		public static void WriteAccountXML(string _username, string _password)
		{
			XDocument doc = XDocument.Load("D:\\GameServer\\Database\\Accounts.xml");

			string now = Convert.ToString(DateTime.Now);
			XElement root = new XElement("Account");
			root.Add(new XAttribute("ID", _username));
			root.Add(new XAttribute("Password", _password));
			root.Add(new XAttribute("DateCreated", now));
			doc.Element("Accounts").Add(root);
			doc.Save("D:\\GameServer\\Database\\Accounts.xml");

			//also add to players.xml the account so a character can be created.
			XDocument playerDoc = XDocument.Load("D:\\GameServer\\Database\\Players.xml");
			XElement root2 = new XElement("Account");
			root2.Add(new XAttribute("ID", _username));
			playerDoc.Element("Players").Add(root2);
			playerDoc.Save("D:\\GameServer\\Database\\Players.xml");

		}

		public static void WritePlayerXML(string _characterName, string _username, List<string> _characterInfo)
		{
			XDocument WritePlayer = XDocument.Load("D:\\GameServer\\Database\\Players.xml");

			// memo for what is in _characterinfo
			// List<string> _characterInfo = new List<string>() { _Race, _Class, _Avatar };
			string playerAccount = _username;
			string playerName = _characterName;
			string playerLevel = "1";
			string playerAvatar = _characterInfo[2];
			string currentHitPoints = "50";
			string maxHitPoints = "50";
			string currentManaPoints = "30";
			string maxManaPoints = "30";
			string currentLocation = "11:10";
			string playerRace = _characterInfo[0];
			string playerClass = _characterInfo[1];
			int[] playerStatMod = PlayerStatModifiers.RaceStatMod[_characterInfo[0]];
			string playerStrength = $"{10 + playerStatMod[0]}";
			string playerDexterity = $"{10 + playerStatMod[1]}";
			string playerConstitution = $"{10 + playerStatMod[2]}";
			string playerIntellect = $"{10 + playerStatMod[3]}";
			string playerWisdom = $"{10 + playerStatMod[4]}";
			string playerCharisma = $"{10 + playerStatMod[5]}";

			IEnumerable<XElement> elements = WritePlayer.Descendants();
			foreach (XElement element in elements)
			{
				if (element.Name == "Account")
				{
					IEnumerable<XAttribute> attribute = element.Attributes();
					foreach (XAttribute eleAttri in attribute)
					{
						if (eleAttri.Value == playerAccount)
						{
							XElement root = element;

							root.Add(new XElement("PlayerName",
								new XAttribute("playerName", playerName),
								new XAttribute("Level", playerLevel),
								new XAttribute("Avatar", playerAvatar),
								new XAttribute("Race", playerRace),
								new XAttribute("Class", playerClass),
								new XAttribute("currentHitPoints", currentHitPoints),
								new XAttribute("maxHitPoints", maxHitPoints),
								new XAttribute("currentManaPoints", currentManaPoints),
								new XAttribute("maxManaPoints", maxManaPoints),
								new XAttribute("currentLocation", currentLocation),
								new XAttribute("carryingWeight", "50"),
								new XAttribute("experience", "0"),
								new XAttribute("skillPoints", "0"),
								new XAttribute("isStealth", "false"),
								//add Stats to player
								new XElement("Stats",
								new XAttribute("Strength", playerStrength),
								new XAttribute("Dexterity", playerDexterity),
								new XAttribute("Constitution", playerConstitution),
								new XAttribute("Intellect", playerIntellect),
								new XAttribute("Wisdom", playerWisdom),
								new XAttribute("Charisma", playerCharisma)),
								new XElement("Inventory",
								new XElement("Item",
								new XAttribute("itemName", "Bandage"),
								new XAttribute("Quantity", "20"))),
								new XElement("Spells",
								new XElement("Spell",
								new XAttribute("SpellName", "ReturnHome"),
								new XAttribute("ManaCost", "10"))),
								new XElement("Quests",
								new XElement("Quest",
								new XAttribute("FirstQuest", "false")))));
							WritePlayer.Save("D:\\GameServer\\Database\\Players.xml");
						}
					}
				}
			}

		}

		public static List<int> GetPlayerStats(string _characterName)
		{
			List<int> _characterStats = new List<int>();

			XDocument doc = XDocument.Load("D:\\GameServer\\Database\\Players.xml");
			IEnumerable<XElement> root = doc.Descendants();
			foreach (XElement ele in root.Elements())
			{
				if (ele.Name == "PlayerName")
				{
					XAttribute attributes = ele.FirstAttribute;
					if (attributes.Value == _characterName)
					{//character found with that name
						IEnumerable<XElement> rootCharacter = ele.Descendants();
						foreach (XElement character in rootCharacter)
						{
							if (character.Name == "Stats")
							{
								XAttribute stats = character.FirstAttribute;
								_characterStats.Add(Convert.ToInt32(stats.Value));
								while ((stats = stats.NextAttribute) != null)
								{
									_characterStats.Add(Convert.ToInt32(stats.Value));
								}
							}
						}

					}
				}
			}
			return _characterStats;
		}
		public static List<string> GetPlayerInfo(string _characterName)
		{
			List<string> _characterInfo = new List<string>();

			XDocument doc = XDocument.Load("D:\\GameServer\\Database\\Players.xml");
			IEnumerable<XElement> root = doc.Descendants();
			foreach (XElement ele in root.Elements())
			{
				if (ele.Name == "PlayerName")
				{
					XAttribute attributes = ele.FirstAttribute;
					if (attributes.Value == _characterName)
					{//character found with that name
						while ((attributes = attributes.NextAttribute) != null)
						{
							_characterInfo.Add(attributes.Value);
						}
					}
				}
			}
			return _characterInfo;
		}
		public static List<string> ReadPlayersXML(string _username, string _password)
		{
			XDocument doc = XDocument.Load("D:\\GameServer\\Database\\Players.xml");
			IEnumerable<XElement> elements = doc.Descendants();
			List<string> Players = new List<string>();
			foreach (XElement element in elements)
			{
				if (element.Name == "Account")
				{
					IEnumerable<XAttribute> attribute = element.Attributes();
					foreach (XAttribute eleAttri in attribute)
					{
						if (eleAttri.Value == _username)
						{
							XElement root = element;
							foreach (XElement ele in root.Elements())
							{
								XAttribute attributes = ele.FirstAttribute;
								Players.Add(Convert.ToString(attributes.Value));
								while ((attributes = attributes.NextAttribute) != null)
								{
									Players.Add(Convert.ToString(attributes.Value));
								}
							}
						}
					}
				}
			}
			return Players;
		}
		public static void SavePlayerStateDisconnect(Player player)
		{
			List<string> _characterInfo = new List<string>();

			XDocument doc = XDocument.Load("D:\\GameServer\\Database\\Players.xml");
			IEnumerable<XElement> root = doc.Descendants();
			foreach (XElement ele in root.Elements())
			{
				if (ele.Name == "PlayerName")
				{
					XAttribute attributes = ele.FirstAttribute;
					if (attributes.Value == player.username)
					{//character found with that name
						while ((attributes = attributes.NextAttribute) != null)
						{
							if (attributes.Name == "Level")
							{
								attributes.Value = Convert.ToString(player.playerLevel);
							}
							if (attributes.Name == "currentHitPoints")
							{
								attributes.Value = Convert.ToString(player.currentHitPoints);
							}
							if (attributes.Name == "maxHitPoints")
							{
								attributes.Value = Convert.ToString(player.maxHitPoints);
							}
							if (attributes.Name == "currentManaPoints")
							{
								attributes.Value = Convert.ToString(player.currentManaPoints);
							}
							if (attributes.Name == "maxManaPoints")
							{
								attributes.Value = Convert.ToString(player.maxManaPoints);
							}
							if (attributes.Name == "currentLocation")
							{
								attributes.Value = Convert.ToString(player.currentLocation.X + ":" + player.currentLocation.Y);
							}
							if (attributes.Name == "carryingWeight")
							{
								attributes.Value = Convert.ToString(player.playerCarryingWeight);
							}
							if (attributes.Name == "experience")
							{
								attributes.Value = Convert.ToString(player.playerExperience);
							}
							if (attributes.Name == "skillPoints")
							{
								attributes.Value = Convert.ToString(player.playerSkillPoints);
							}
							if (attributes.Name == "isStealth")
							{
								attributes.Value = Convert.ToString(player.isStealth);
							}
						}
						IEnumerable<XElement> rootCharacter = ele.Descendants();
						foreach (XElement character in rootCharacter)
						{
							if (character.Name == "Stats")
							{
								XAttribute stats = character.FirstAttribute;
								if (stats.Name == "Strength")
								{
									stats.Value = Convert.ToString(player.playerStrength);
								}
								while ((stats = stats.NextAttribute) != null)
								{
									if (stats.Name == "Strength")
									{
										stats.Value = Convert.ToString(player.playerStrength);
									}
									if (stats.Name == "Dexterity")
									{
										stats.Value = Convert.ToString(player.playerDexterity);
									}
									if (stats.Name == "Constitution")
									{
										stats.Value = Convert.ToString(player.playerConstitution);
									}
									if (stats.Name == "Intellect")
									{
										stats.Value = Convert.ToString(player.playerIntellect);
									}
									if (stats.Name == "Wisdom")
									{
										stats.Value = Convert.ToString(player.playerWisdom);
									}
									if (stats.Name == "Charisma")
									{
										stats.Value = Convert.ToString(player.playerCharisma);
									}
								}
							}
						}
					}
				}
			}
			doc.Save("D:\\GameServer\\Database\\Players.xml");
		}
		public static void DeleteAccountXML(string _username, string _password)
		{
			bool correctAccountAndPassword = false;
			XDocument doc = XDocument.Load("D:\\GameServer\\Database\\Accounts.xml");
			IEnumerable<XElement> Accountelements = doc.Descendants();
			List<XElement> AccountToDelete = new List<XElement>();
			foreach (XElement element in Accountelements)
			{
				//reads through xml document and finds elements with the name Account.
				if (element.Name == "Account")
				{
					//adds the values of the accounts ID // PASSWORD // DateCreated
					XAttribute attributes = element.FirstAttribute;
					Console.WriteLine(attributes.Value);
					if(attributes.Value == _username)
                    {
						if(attributes.NextAttribute.Value == _password)
                        {
							AccountToDelete.Add(element);
							correctAccountAndPassword = true;

						}
                    }
				}
			}
			if (correctAccountAndPassword)
			{
				foreach (XElement element in AccountToDelete)
				{
					element.Remove();
				}
				doc.Save("D:\\GameServer\\Database\\Accounts.xml");

				List<XElement> CharacterToDelete = new List<XElement>();
				XDocument doc2 = XDocument.Load("D:\\GameServer\\Database\\Players.xml");
				IEnumerable<XElement> root2 = doc2.Descendants();
				foreach (XElement ele in root2.Elements())
				{
					if (ele.Name == "Account")
					{
						XAttribute attributes = ele.FirstAttribute;
						if (attributes.Value == _username)
						{
							CharacterToDelete.Add(ele);
						}
					}
				}
				foreach (XElement element in CharacterToDelete)
				{
					element.Remove();
				}
				doc2.Save("D:\\GameServer\\Database\\Players.xml");
			}
		}
		public static void DeleteCharacterXML(string _username, string _password, string _characterName)
        {
			List<XElement> CharacterToDelete = new List<XElement>();
			XDocument doc = XDocument.Load("D:\\GameServer\\Database\\Players.xml");
			IEnumerable<XElement> root = doc.Descendants();
			foreach (XElement ele in root.Elements())
			{
				if (ele.Name == "PlayerName")
				{
					XAttribute attributes = ele.FirstAttribute;
					if (attributes.Value == _characterName)
					{
						CharacterToDelete.Add(ele);
					}
				}
			}
			foreach (XElement element in CharacterToDelete)
			{
				element.Remove();
			}
			doc.Save("D:\\GameServer\\Database\\Players.xml");
		}
	}
}
