﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JECS.Tests
{
    [TestClass]
    public class SaveLoad_StringTests
    {
        // string tests are extremely comprehensive because there are SO many different ways a string can fuck up the parsing logic.

        [TestMethod]
        [DataRow("", DisplayName = "empty string")]
        [DataRow(" ", DisplayName = "single space")]
        [DataRow(null, DisplayName = "null")]
        [DataRow("null", DisplayName = "'null'")]
        [DataRow("   boobs", DisplayName = "leading spaces")]
        [DataRow("boobs   ", DisplayName = "trailing spaces")]
        [DataRow("   boobs   ", DisplayName = "leading and trailing spaces")]
        [DataRow("\"", DisplayName = "double quotes")]
        [DataRow("\"\"", DisplayName = "double quotes x2")]
        [DataRow("\"\"\"", DisplayName = "double quotes x3")]
        [DataRow(@"\", DisplayName = "backslash")]
        [DataRow("#", DisplayName = "pound sign")]
        [DataRow("##", DisplayName = "pound sign x2")]
        [DataRow("###", DisplayName = "pound sign x3")]
        [DataRow("this is #not a #comment!", DisplayName = "fake comment")]
        [DataRow("🎃", DisplayName = "emoji")]
        [DataRow(multiLineString, DisplayName = "multi line string")]
        [DataRow(multiLineStringWithPoundSigns, DisplayName = "multi line string with pound signs")]
        [DataRow(multiLineStringWithDoubleQuotes, DisplayName = "multi line string with double quotes")]
        [DataRow(multiLineStringWithLeadingTrailingSpaces, DisplayName = "multi line string with leading and trailing spaces")]
        [DataRow(multiLineStringWithBackslashes, DisplayName = "multi line string with backslashes")]
        [DataRow(veryLongString, DisplayName = "very long string")]
        [DataRow(poem, DisplayName = "poem")]
        [DataRow(genemoji, DisplayName = "genemoji")]
        public void SaveLoad_String(string SAVED_VALUE)
            => TestUtilities.PerformSaveLoadTest(SAVED_VALUE);

        [TestMethod]
        public void SaveLoad_String_NewLine()
            => TestUtilities.PerformSaveLoadTest(Environment.NewLine);

        [TestMethod]
        public void SaveLoad_String_NewLinex3()
            => TestUtilities.PerformSaveLoadTest(Environment.NewLine + Environment.NewLine + Environment.NewLine);

        const string multiLineString = @"
this is a
string with multiple lines
";

        const string multiLineStringWithPoundSigns = @"
this is a
string with multiple lines
and #pound #signs
####
#yolo
yolo#
";

        const string multiLineStringWithDoubleQuotes = @"
this is a
string with multiple lines
and ""double quotes""
""""
""""""
""yolo
yolo""
""yolo""
";

        const string multiLineStringWithLeadingTrailingSpaces = @"
this is a
string with multiple lines
   and leading spaces
and trailing spaces    
    and both!    
";

        const string multiLineStringWithBackslashes = @"

\

\\

\\\\\

""\""

";

        const string veryLongString = "What the fuck did you just fucking say about me, you little bitch? I'll have you know I graduated top of my public class in the Navy Seals, and I've been involved in numerous secret raids on Al-Quaeda, and I have over 300 confirmed kills. I am trained in gorilla warfare and I'm the top sniper in the entire US armed forces. You are nothing to me but just another target. I will wipe you the fuck out with precision the likes of which has never been seen before on this Earth, mark my fucking words. You think you can get away with saying that shit to me over the Internet? Think again, fucker. As we speak I am contacting my secret network of spies across the USA and your IP is being traced right now so you better prepare for the storm, maggot. The storm that wipes out the pathetic little thing you call your life. You're fucking dead, kid. I can be anywhere, anytime, and I can kill you in over seven hundred ways, and that's just with my bare hands. Not only am I extensively trained in unarmed combat, but I have access to the entire arsenal of the United States Marine Corps and I will use it to its full extent to wipe your miserable ass off the face of the continent, you little shit. If only you could have known what unholy retribution your little \"clever\" comment was about to bring down upon you, maybe you would have held your fucking tongue. But you couldn't, you didn't, and now you're paying the price, you goddamn idiot. I will shit fury all over you and you will drown in it. You're fucking dead, kiddo.";

        // [i carry your heart with me(i carry it in] 
        // by E. E. Cummings
        const string poem = @"
i carry your heart with me(i carry it in
my heart)i am never without it(anywhere
i go you go,my dear;and whatever is done
by only me is your doing,my darling)
                                                      i fear
no fate(for you are my fate,my sweet)i want
no world(for beautiful you are my world,my true)
and it’s you are whatever a moon has always meant
and whatever a sun will always sing is you

here is the deepest secret nobody knows
(here is the root of the root and the bud of the bud
and the sky of the sky of a tree called life;which grows
higher than soul can hope or mind can hide)
and this is the wonder that's keeping the stars apart

i carry your heart(i carry it in my heart)
";
        const string genemoji = @"
1 In the beginning🌄 God ⛏️🛠️created⚒️🔨 the heavens🌤️ and the 🌍🌎earth🌏🗺️. 2 Now the 🌍🌎earth🌏🗺️ was formless and empty, 🌚darkness🌚 was over the surface of the deep, and the 👻Spirit👻 of God was hovering over the 🌊💧waters💦💦💦.

3 And God said🗣️, “Let there be🐝 light💡,” and there was light💡. 4 God saw👁️ that the 🌝light🌝 was good👍👌👌, and he separated the 🌝light🌝 from the 🌚darkness🌚. 5 God called📞 the 🌝light🌝 “day☀️,” and the 🌚darkness🌚 he called📞 “night🌙.” And there was 🌙evening, and there was ☀️morning—the 🥇first ☀️day☀️.

6 And God said🗣️, “Let there be🐝 a🅰️ vault ➡️between⬅️ the 🌊💧waters💦💦 to2️⃣ separate 🌊💧water💦💦 from 🌊💧water💦💦.” 7 So God ⛏️⚒️made🛠️🔨 the vault and separated the 🌊💧water💦💦 under the vault from the 🌊💧water💦💦 above it. And it was so. 8 God called📞 the vault “sky🌥️.” And there was 🌙evening, and there was ☀️morning—the 🥈second ☀️day☀️.

9 And God said🗣️, “Let the 🌊💧water💦💦 under the 🌥️sky be🐝 gathered to2️⃣ one1️⃣ place, and let dry🌵 ground appear.” And it was so. 10 God called📞 the dry ground “land🗺️,” and the gathered 🌊💧waters💦💦 he called📞 “seas🗺️.” And God saw👁️ that it was good👍👌👌.

11 Then God said🗣️, “Let the land🗺️ produce 🌱🌲vegetation🌳🌴: seed-bearing plants🌱 and 🌲🌳trees🌴🌴 on the land🗺️ that bear 🍇🍈🍉🍊🍋🍌🍍fruit🍎🍏🍐🍑🍒🍓🥝 with seed in it, according to2️⃣ their various kinds.” And it was so. 12 The land🗺️ produced 🌱🌲vegetation🌳🌴: plants🌱 bearing seed according to2️⃣ their kinds and 🌲🌳trees🌴🌴 🐻bearing🐼 🍇🍈🍉🍊🍋🍌🍍fruit🍎🍏🍐🍑🍒🍓🥝 with seed in it according to2️⃣ their kinds. And God saw👁️ that it was good👍👌👌. 13 And there was evening🌙, and there was morning☀️—the 🥉third ☀️day☀️.

14 And God said🗣️, “Let there be🐝 🌝lights🌝 in the vault of the sky🌥️ to2️⃣ separate the ☀️day☀️ from the 🌙night🌙, and let them serve as signs to2️⃣ mark sacred ⌚⏰⏱️times⏲️🕰️🕛, and days📆 and years📅, 15 and let them be🐝 🌝lights🌝 in the vault of the sky🌥️ to2️⃣ give 🌝light🌝 on the 🌍🌎earth🌏🗺️.” And it was so. 16 God ⛏️⚒️made🛠️🔨 two2️⃣ great 🌝lights🌝—the greater 🌞light☀️ to govern the ☀️day☀️ and the lesser 🌛light🌜 to govern the 🌙night🌙. He also made the ✨stars✨. 17 God set them in the vault of the sky🌥️ to give 🌝light🌝 on the 🌏🗺️earth🌍🌎, 18 to2️⃣ govern the ☀️day☀️ and the 🌙night🌙, and to2️⃣ separate 🌝light🌝 from 🌚darkness🌚. And God saw👁️ that it was good👍👌👌. 19 And there was evening🌙, and there was morning☀️—the 4️⃣fourth ☀️day☀️.

20 And God said🗣️, “Let the 🌊💧water💦💦 teem with living creatures, and let 🦃🐔🐓🐣🕊️🦅birds🐤🐥🐦🐧🦆🦉 fly above🔝 the 🌍🌎earth🌏🗺️ across the vault of the sky🌥️.” 21 So God ⛏️⚒️created🛠️🔨 the great creatures of the 🗺️sea and every living thing with which the 🌊💧water💦💦 teems and that moves about in it, according to2️⃣ their kinds, and every winged 🦃🐔🐓🐣🐤🐥bird🐦🐧🕊️🦅🦆🦉 according to2️⃣ its kind. And God saw👁️ that it was good👍👌👌. 22 God 😇blessed😇 them and said🗣️, “Be 🍇🍈🍉🍊🍋🍌🍍fruitful🍎🍏🍐🍑🍒🍓🥝 and increase➕ in number#️⃣ and fill the 🌊💧water💦💦 in the seas🗺️, and let the 🦃🐔🐓🐣🐤🐥birds🐦🐧🕊️🦅🦆🦉 increase➕ on🔛 the 🌍🌎earth🌏🗺️.” 23 And there was evening🌙, and there was morning☀️—the 5️⃣fifth ☀️day☀️.

24 And God said🗣️, “Let the 🗺️land produce living creatures according to2️⃣ their kinds: the 🐮🐄🐷🐖🐗🐪🐫livestock🐏🐑🐔🐓🐣🐤🐥, the creatures that move along the 🐫🐪ground🐴🐎, and the 🐬🐟🦈🐙🐨🐼🐺🦊🦁🐯wild🦀🐍🐧🦌🐘 🦏🐿️🦅🦑🐊animals🐌🦂🦇🐻🐅🐆🐒🦍🐳🐋, each according to2️⃣ its kind.” And it was so. 25 God ⛏️⚒️made🛠️🔨 the 🐬🐟🦈🐙🐨🐼🐺🦊🦁🐯wild🦀🐍🐧🦌🐘 🦏🐿️🦅🦑🐊animals🐌🦂🦇🐻🐅🐆🐒🦍🐳🐋 according to2️⃣ their kinds, the 🐮🐄🐷🐖🐗🐪🐫livestock🐏🐑🐔🐓🐣🐤🐥 according to2️⃣ their kinds, and all the creatures that move along the ground according to2️⃣ their kinds. And God saw👁️ that it was good👍👌👌.

26 Then God said🗣️, “Let us ⛏️⚒️make🛠️🔨 mankind in our image🖼️, in our likeness, so that they may rule over the 🦈🐙fish🦀🦐 in the sea🗺️ and the 🦃🐔🐓🐣🐤🐥birds🐦🐧🕊️🦅🦆🦉 in the sky🌥️, over the 🐮🐄🐷🐖🐗🐪🐫livestock🐏🐑🐔🐓🐣🐤🐥 and all the 🐬🐟🦈🐙🐨🐼🐺🦊🦁🐯wild🦀🐍🐧🦌🐘 🦏🐿️🦅🦑🐊animals🐌🦂🦇🐻🐅🐆🐒🦍🐳🐋, and over all the creatures that move along the ground.”

27 So God ⛏️⚒️created🛠️🔨 mankind in his own image🖼️,
    in the image🖼️ of God he ⚒️⛏️created🔨🛠️ them;
    male♂️ and female♀️ he ⛏️⚒️created🛠️🔨 them.

28 God 😇blessed😇🙏 them and said🗣️ to2️⃣ them, “Be🐝 🍇🍈🍉🍊🍋🍌🍍fruitful🍎🍏🍐🍑🍒🍓🥝 and increase➕ in number#️⃣; fill the 🌍🌎earth🌏🗺️ and subdue it. Rule over the 🦈🐙fish🦀🦐 in the sea🗺️ and the 🦃🐔🐓🐣🐤🐥birds🐦🐧🕊️🦅🦆🦉 in the sky🌥️ and over every living creature that moves on the ground.”

29 Then God said🗣️, “I👀 give you every seed-bearing plant🌱 on the face😎 of the whole 🌍🌎earth🌏🗺️ and every 🌲🌳tree🌴🌴 that has 🍇🍈🍉🍊🍋🍌🍍fruit🍎🍏🍐🍑🍒🍓🥝 with seed in it. They will be 🐝yours for4️⃣ 🍉🥕🌶️🍄🥒🥜🍗🍞🥖🍟🥞🧀🌭🌮🥙🥚food🥘🍲🥗🍿🍱🍘🍛🍜🍝🍡🍦🍢🍨🍣🍩🎂🍪🍰☕🥛🍺🍬🍮🥃🍶. 30 And to2️⃣ all the beasts👹👺 of the 🌍🌎earth🌏🗺️ and all the 🦃🐔🐓🐣🐤🐥birds🐦🐧🕊️🦅🦆🦉 in the sky🌥️ and all the creatures that move along the ground—everything that has the breath🌬️ of life in it—I👀 give every 💚green💚 plant🌱 for4️⃣ 🍉🥕🌶️🍄🥒🥜🍗🍞🥖🍟🥞🧀🌭🌮🥙🥚food🥘🍲🥗🍿🍱🍘🍛🍜🍝🍡🍦🍢🍨🍩🎂🍪🍰☕🥛🍺🍬🍮🥃🍶.” And it was so.

31 God saw👁️ all that he had ⛏️⚒️made🛠️🔨, and it was very good👍👌👌. And there was evening🌙, and there was morning☀️—the 6️⃣sixth ☀️day☀️.

2 Thus the heavens🌤️ and the 🌍🌎earth🌏🗺️ were completed in all their vast array.

2 By the 7️⃣seventh ☀️day☀️ God had finished the work he had been doing; so on the 7️⃣seventh ☀️day☀️ he 💤rested💤 from all his work. 3 Then God 😇blessed😇🙏 the 7️⃣seventh ☀️day☀️ and made it holy✝️😇🙏, because on it he 💤rested💤 from all the work of⛏️⚒️ creating🛠️🔨 that he had done.

";
    }
}
