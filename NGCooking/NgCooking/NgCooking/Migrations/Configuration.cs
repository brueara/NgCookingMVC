namespace NgCooking.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NgCooking.DAL.NgCookingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NgCooking.DAL.NgCookingContext context)
        {
            var categories = new List<Categorie>
            {
                new Categorie
                {
                    id = "meat",
                    nameToDisplay = "Viandes"
                },
                new Categorie
                {
                    id = "fish",
                    nameToDisplay = "Poissons"
                },
                new Categorie
                {
                    id = "seafood",
                    nameToDisplay = "Fruits de mer"
                },
                new Categorie
                {
                    id = "fruit",
                    nameToDisplay = "Fruits"
                },
                new Categorie
                {
                    id = "vegetable",
                    nameToDisplay = "Légumes"
                },
                new Categorie
                {
                    id = "drink",
                    nameToDisplay = "Boissons"
                },
                new Categorie
                {
                    id = "alcohol",
                    nameToDisplay = "Alcools"
                },
                new Categorie
                {
                    id = "cereal",
                    nameToDisplay = "Céréales"
                },
                new Categorie
                {
                    id = "dairy-product",
                    nameToDisplay = "Produits laitiers"
                },
                new Categorie
                {
                    id = "cheese",
                    nameToDisplay = "Fromages"
                },
                new Categorie
                {
                    id = "other",
                    nameToDisplay = "Autre"
                }
                };

            categories.ForEach(s => context.Categories.AddOrUpdate(p => p.id, s));
            context.SaveChanges();

            var ingredients = new List<Ingredient>
            {
               new Ingredient
                {
                id = "pomme-de-terre",
                name = "Pomme de terre",
                isAvailable = true,
                picture = "pomme-de-terre.jpg",
                description = "La pomme de terre, ou patate (langage familier, canadianisme et belgicisme), est un tubercule comestible produit par l’espèce Solanum tuberosum, appartenant à la famille des solanacées. Le terme désigne également la plante elle-même, plante herbacée, vivace par ses tubercules mais toujours cultivée comme une culture annuelle. La pomme de terre est une plante qui réussit dans la plupart des sols, mais elle préfère les sols légers légèrement acides. La plante est sujette aux maladies dans des sols calcaires ou manquant d’humus.",
                calories = 140,
                CategoryId = categories.Find(s => s.id == "vegetable").id
                },
                new Ingredient
                {
                id = "boeuf",
                name = "Boeuf",
                isAvailable = true,
                picture = "boeuf.jpg",
                description = "Un boeuf est un taureau castré, plus précisément un bovin (Bos taurus) domestique mâle ayant subi une castration dans le cadre de son élevage. Devenus plus calmes, ces animaux sont principalement destinés à la production d'animaux robustes destinés à la traction bovine ou à production de viande bovine. Cette pratique devient moins fréquente en occident, mais c'était par le passé la principale viande, d'où le nom générique de « viande de bœuf », ou plus simplement « bœuf », encore employé couramment pour désigner toutes sortes de viandes bovines dans le langage courant.",
                calories = 200,
                CategoryId = categories.Find(s => s.id == "meat").id
                },
                new Ingredient
                {
                id = "poulet",
                name = "Poulet",
                isAvailable = true,
                picture = "poulet.jpg",
                CategoryId = categories.Find(s => s.id == "meat").id,
                description = "Un poulet est une jeune volaille, mâle ou femelle, de la sous-espèce Gallus gallus domesticus, élevée pour sa chair.Un petit poulet mâle est un coquelet, un poulet femelle est une poulette. Un jeune coq châtré pour que sa chair soit plus tendre est un chapon, une poulette à laquelle on a ôté les ovaires pour le même motif est une poularde. En France, le poulet est abattu entre quarante jours et jusqu'à 6 mois après sa naissance, selon le mode de production (élevage industriel ou traditionnel).",
                calories = 180
                },
                 new Ingredient
                {
                id = "citron",
                name = "Citron",
                isAvailable = true,
                picture = "citron.jpg",
                CategoryId = categories.Find(s => s.id == "fruit").id,
                description = "Le citron est un agrume, fruit du citronnier, dont le jus a un pH de 2,5. Le citronnier (Citrus limon) est un arbuste de 5 à 10 mètres de haut, à feuilles persistantes, de la famille des Rutacées. Ce fruit mûr a une écorce qui va du vert tendre au jaune éclatant sous l'action du froid. La maturité est en fin d'automne et début d'hiver dans l’hémisphère nord. Sa chair est juteuse, acide et riche en vitamine C, ce qui lui vaut - avec sa conservation facile - d'avoir été diffusé sur toute la planète par les navigateurs qui l'utilisent pour prévenir le scorbut.",
                calories = 110
                },
                  new Ingredient
                {
                id = "sucre",
                name = "Sucre",
                isAvailable = true,
                picture = "sucre.jpg",
                CategoryId = categories.Find(s => s.id == "other").id,
                description = "Le sucre est une substance de saveur douce extraite principalement de la canne à sucre et de la betterave sucrière. Il est majoritairement formé d'un composé nommé saccharose. Le terme « sucre » provient du terme italien « zucchero », lui-même emprunté à l'arabe « sukkar » (سكر), mot d'origine indienne, en sanscrit « çârkara ». D'autres plantes permettent également de produire des produits composés majoritairement de saccharose.",
                calories = 600
                },
                   new Ingredient
                {
                id = "farine",
                name = "Farine",
                isAvailable = true,
                picture = "farine.jpg",
                CategoryId = categories.Find(s => s.id == "other").id,
                description = "La farine est une poudre obtenue en broyant et en moulant des céréales ou d'autres produits alimentaires solides, souvent des graines. La farine issue de céréales contenant du gluten, comme le blé, est l'un des principaux éléments de l'alimentation de certains peuples du monde. Elle est à la base de la fabrication des pains, des pâtes, des crêpes, des pâtisseries et de plusieurs mets préparés.",
                calories = 310
                },
                    new Ingredient
                {
                id = "tomate",
                name = "Tomate",
                isAvailable = true,
                picture = "tomate.jpg",
                CategoryId = categories.Find(s => s.id == "fruit").id,
                description = "La tomate (Solanum lycopersicum L.) est une espèce de plantes herbacées de la famille des Solanacées, originaire du Nord-Ouest de l'Amérique du Sud1, largement cultivée pour son fruit. Le terme désigne aussi ce fruit charnu. La tomate se consomme comme un légume-fruit, crue ou cuite. Elle est devenue un élément incontournable de la gastronomie dans de nombreux pays, et tout particulièrement dans le bassin méditerranéen.",
                calories = 80
                },
                     new Ingredient
                {
                id = "carotte",
                name = "Carotte",
                isAvailable = true,
                picture = "carotte.jpg",
                CategoryId = categories.Find(s => s.id == "vegetable").id,
                description = "La carotte (Daucus carota subsp. sativus) est une plante bisannuelle de la famille des apiacées (anciennement ombellifères), largement cultivée pour sa racine pivotante charnue, comestible, de couleur généralement orangée, consommée comme légume.",
                calories = 180
                },
                      new Ingredient
                {
                id = "ananas",
                name = "Ananas",
                isAvailable = true,
                picture = "ananas.jpg",
                CategoryId = categories.Find(s => s.id == "fruit").id,
                description = "L'ananas (Ananas comosus) est une plante xérophyte, originaire d'Amérique du Sud plus spécifiquement du Paraguay nord-est Argentine et sud du Bresil. Il est connu principalement pour son fruit comestible, qui est en réalité un fruit composé. Le mot ananas vient du tupi-guarani naná naná, qui signifie « parfum des parfums ».",
                calories = 95
                },
                       new Ingredient
                {
                id = "aubergine",
                name = "Aubergine",
                isAvailable = true,
                picture = "aubergine.jpg",
                CategoryId = categories.Find(s => s.id == "vegetable").id,
                description = "L’aubergine (Solanum melongena L.) est une plante potagère herbacée de la famille des Solanacées, cultivée pour son fruit consommé comme légume-fruit. Le terme désigne la plante et le fruit. Deux autres aubergines cultivées en Afrique sont appelées couramment « aubergines africaines » : Solanum aethiopicum L. ou gilo et Solanum macrocarpon L. ou gboma.",
                calories = 50
                },
                        new Ingredient
                {
                id = "banane",
                name = "Banane",
                isAvailable = true,
                picture = "banane.jpg",
                CategoryId = categories.Find(s => s.id == "fruit").id,
                description = "La banane est le fruit ou la baie dérivant de l’inflorescence du bananier. Les bananes sont des fruits très généralement stériles issus de variétés domestiquées. Les fruits des bananiers sauvages et de quelques cultivars domestiques contiennent des graines. Les bananes sont généralement jaunes lorsqu'elles sont mûres et vertes quand elles ne le sont pas.",
                calories = 210
                },
                          new Ingredient
                {
                id = "biere",
                name = "Bière",
                isAvailable = true,
                picture = "biere.jpg",
                CategoryId = categories.Find(s => s.id == "alcohol").id,
                description = "La bière est une boisson alcoolisée obtenue par fermentation de matières glucidiques végétales et d'eau. C'est une boisson alcoolisée obtenue par transformation de matières amylacées par voies enzymatiques et microbiologiques.",
                calories = 140
                },
                            new Ingredient
                {
                id = "brocolis",
                name = "Brocolis",
                isAvailable = true,
                picture = "brocolis.jpg",
                CategoryId = categories.Find(s => s.id == "vegetable").id,
                description = "Le brocoli (Brassica oleracea var. italica) est une variété de chou originaire du sud de l'Italie. Il fut sélectionné par les Romains à partir du chou sauvage. Ceux-ci l'appréciaient beaucoup, et la cuisine italienne l'utilise beaucoup. Il fut introduit en France par Catherine de Médicis.",
                calories = 80
                },
                              new Ingredient
                {
                id = "citron-vert",
                name = "Citron vert",
                isAvailable = true,
                picture = "citron-vert.jpg",
                CategoryId = categories.Find(s => s.id == "fruit").id,
                description = "La lime, lime acide ou citron vert est un agrume. C'est le fruit du limettier, arbuste de la famille des Rutacées, dont il existe deux espèces : Citrus x latifolia et Citrus x aurantiifolia.",
                calories = 80
                },
                        new Ingredient
                {
                id = "colin",
                name = "Colin",
                isAvailable = true,
                picture = "colin.jpg",
                CategoryId = categories.Find(s => s.id == "fish").id,
                description = "Le Colin d'Alaska (Theragra chalcogramma) ou lieu d'Alaska ou Goberge de l'Alaska (Canada) est un poisson d'eau de mer de la famille des Gadidae qui se rencontre dans le nord de l'océan Pacifique. Contrairement à ce que son nom vernaculaire pourrait suggérer, il n'appartient pas au même genre que les Colins d'Atlantique, nom générique donné aux poissons du genre Pollachius.",
                calories = 80
                },
                               new Ingredient
                {
                id = "creme",
                name = "Crème",
                isAvailable = true,
                picture = "creme.jpg",
                CategoryId = categories.Find(s => s.id == "dairy-product").id,
                description = "La crème est la matière grasse du lait obtenue par écrémage. La crème aigre, crème fraîche liquide, crème fraîche épaisse... ainsi que le beurre, sont des produits laitiers issus de cette crème.",
                calories = 180
                },
                                new Ingredient
                {
                id = "crevettes",
                name = "Crevettes",
                isAvailable = true,
                picture = "crevettes.jpg",
                CategoryId = categories.Find(s => s.id == "seafood").id,
                description = "Le nom vernaculaire crevette (aussi connu comme chevrette dans certaines régions de la francophonie) est traditionnellement donné à un ensemble de crustacés aquatiques, essentiellement marins mais aussi dulcicoles, autrefois regroupés dans le sous-ordre des « décapodes nageurs », ou Natantia.",
                calories = 180
                },
                new Ingredient
                {
                id = "echalotte",
                name = "Echalotte",
                isAvailable = true,
                picture = "echalotte.jpg",
                CategoryId = categories.Find(s => s.id == "vegetable").id,
                description = "L'échalote ou échalotte est une plante bulbeuse de la famille des Amaryllidacées, cultivée comme plante condimentaire et potagère. Le terme désigne aussi le bulbe lui-même, qui fait partie depuis longtemps de la gastronomie française.",
                calories = 30
                },
                new Ingredient
                {
                id = "fraise",
                name = "Fraise",
                isAvailable = true,
                picture = "fraise.jpg",
                CategoryId = categories.Find(s => s.id == "fruit").id,
                description = "Ce fruit est botaniquement parlant un faux-fruit puisqu'il s'agit en réalité d'un réceptacle charnu sur lequel sont disposés régulièrement des akènes dans des alvéoles plus ou moins profondes, la fraise étant donc un polyakène. Quelques fruits d'autres espèces sans rapport avec Fragaria, et par analogie de forme, portent le nom vernaculaire de fraise.",
                calories = 130
                },
                new Ingredient
                {
                id = "glace",
                name = "Glace",
                isAvailable = true,
                picture = "glace.jpg",
                CategoryId = categories.Find(s => s.id == "other").id,
                description = "La glace est l'eau (de formule chimique H2O) lorsqu'elle est à l'état solide. Cet élément est très étudié dans la nature et en laboratoire, par les scientifiques, à commencer par les glaciologues, les physiciens de la matière condensée et autres cryologues de spécialités différentes : il contient souvent beaucoup d'impuretés ou d'inclusions, d'origine diverse.",
                calories = 0
                },
                new Ingredient
                {
                id = "gruyere",
                name = "Gruyère",
                isAvailable = true,
                picture = "gruyere.jpg",
                CategoryId = categories.Find(s => s.id == "cheese").id,
                description = "Le gruyère d'alpage est lui fabriqué seulement dans une cinquantaine d'alpages réparties dans trois cantons : Fribourg, Vaud, Jura bernois; celui de Vaud fabrique, en 2014, les trois cinquième de la production.",
                calories = 430
                },
                new Ingredient
                {
                id = "huile-olive",
                name = "Huile d'olive",
                isAvailable = true,
                picture = "huile-olive.jpg",
                CategoryId = categories.Find(s => s.id == "other").id,
                description = "L’huile d'olive est la matière grasse extraite des olives (fruits de l'olivier) lors de la trituration dans un moulin à huile. Elle est un des fondements de la cuisine méditerranéenne et est, sous certaines conditions, bénéfique pour la santé.",
                calories = 850
                },
                new Ingredient
                {
                id = "huile-tournesol",
                name = "Huile de tournesol",
                isAvailable = true,
                picture = "huile-tournesol.jpg",
                CategoryId = categories.Find(s => s.id == "other").id,
                description = "L'huile de tournesol est une huile végétale obtenue à partir des graines de tournesol.",
                calories = 900
                },
                new Ingredient
                {
                id = "jambon",
                name = "Jambon",
                isAvailable = true,
                picture = "jambon.jpg",
                CategoryId = categories.Find(s => s.id == "meat").id,
                description = "Le jambon est la cuisse entière d'un animal destinée à être préparée crue (après salaison, séchage et parfois fumage) ou cuite (rôtie, grillée, braisée ou, comme le jambon blanc, bouillie).",
                calories = 270
                },
                new Ingredient
                {
                id = "kiwi",
                name = "Kiwi",
                isAvailable = true,
                picture = "kiwi.jpg",
                CategoryId = categories.Find(s => s.id == "fruit").id,
                description = "Les kiwis sont des fruits de plusieurs espèces de lianes du genre Actinidia, famille des Actinidiaceae. Ils sont originaires de Chine, notamment de la province de Shaanxi. On en trouve par ailleurs dans des climats dits montagnards tropicaux. En France, les kiwis de l'Adour disposent d'une IGP et d'un label rouge.",
                calories = 145
                },
                new Ingredient
                {
                id = "lait",
                name = "Lait",
                isAvailable = true,
                picture = "lait.jpg",
                CategoryId = categories.Find(s => s.id == "dairy-product").id,
                description = "Le lait est un liquide biologique comestible généralement de couleur blanchâtre produit par les glandes mammaires des mammifères femelles.",
                calories = 500
                },
                new Ingredient
                {
                id = "mais",
                name = "Maïs",
                isAvailable = true,
                picture = "mais.jpg",
                CategoryId = categories.Find(s => s.id == "cereal").id,
                description = "Le maïs (Zea mays L., ou Zea mays subsp. mays (autonyme)), ou blé d’Inde au Canada, est une plante herbacée tropicale annuelle de la famille des Poacées (graminées), largement cultivée comme céréale pour ses grains riches en amidon, mais aussi comme plante fourragère. Le terme désigne aussi le grain de maïs lui-même.",
                calories = 160
                },
                new Ingredient
                {
                id = "noix-de-coco",
                name = "Noix de coco",
                isAvailable = true,
                picture = "noix-de-coco.jpg",
                CategoryId = categories.Find(s => s.id == "fruit").id,
                description = "La noix de coco est le fruit du cocotier (Cocos nucifera), un des représentants de la famille des palmiers ou Arécacées.",
                calories = 100
                },
                new Ingredient
                {
                id = "oeuf",
                name = "Oeuf",
                isAvailable = true,
                picture = "oeuf.jpg",
                CategoryId = categories.Find(s => s.id == "other").id,
                description = "L’œuf de volaille est un produit agricole servant d'ingrédient entrant dans la composition de nombreux plats, dans de nombreuses cultures gastronomiques du monde.",
                calories = 450
                },
                new Ingredient
                {
                id = "olives",
                name = "Olives",
                isAvailable = true,
                picture = "olives.jpg",
                CategoryId = categories.Find(s => s.id == "fruit").id,
                description = "L’olive est le fruit de l'olivier, un arbre fruitier caractéristique des régions méditerranéennes.",
                calories = 180
                },
                new Ingredient
                {
                id = "orange",
                name = "Orange",
                isAvailable = true,
                picture = "orange.jpg",
                CategoryId = categories.Find(s => s.id == "fruit").id,
                description = "L’orange est un agrume, fruit des orangers, des arbres de différentes espèces de la famille des Rutacées ou d'hybrides de ceux-ci.",
                calories = 105
                },
                new Ingredient
                {
                id = "pamplemousse",
                name = "Pamplemousse",
                isAvailable = true,
                picture = "pamplemousse.jpg",
                CategoryId = categories.Find(s => s.id == "fruit").id,
                description = "Le Pomélo, Pomelo ou pamplemousse (Citrus ×paradisi Macfad., synonyme Citrus paradisi), ou fruit défendu (Guadeloupe et Martinique) ou encore chadègue (cajun), est un arbre fruitier de la famille des Rutaceae.",
                calories = 100
                },
                new Ingredient
                {
                id = "pasteque",
                name = "Pastèque",
                isAvailable = true,
                picture = "pasteque.jpg",
                CategoryId = categories.Find(s => s.id == "fruit").id,
                description = "La pastèque (Citrullus lanatus (Thunb.) Matsum. & Nakai, 1916), aussi appelée melon d'eau, notamment au Canada francophone, est une espèce de plantes herbacées de la famille des Cucurbitacées, originaire d'Afrique de l'Ouest, largement cultivée pour ses gros fruits lisses, à chair rouge, jaune, verdâtre ou blanche et à graines noires ou rouges.",
                calories = 40
                },
                new Ingredient
                {
                id = "poire",
                name = "Poire",
                isAvailable = true,
                picture = "poire.jpg",
                CategoryId = categories.Find(s => s.id == "fruit").id,
                description = "La poire est un fruit à pépins comestible au goût doux et sucré dont il existe plus de deux mille variétés cultivées. Le premier pays producteur en est la Chine et c'est le cinquième fruit le plus consommé en France.",
                calories = 65
                },
                new Ingredient
                {
                id = "pomme",
                name = "Pomme",
                isAvailable = true,
                picture = "pomme.jpg",
                CategoryId = categories.Find(s => s.id == "fruit").id,
                description = "La pomme est un fruit comestible à pépins d'un goût sucré ou acidulé selon les variétés. D'un point de vue botanique, il s'agit d'un faux fruit. Elle est produite par le pommier, arbre du genre Malus.",
                calories = 55
                },
                new Ingredient
                {
                id = "raisin",
                name = "Raisin",
                isAvailable = true,
                picture = "raisin.jpg",
                CategoryId = categories.Find(s => s.id == "fruit").id,
                description = "Le raisin est le fruit de la Vigne (Vitis). Le raisin de la vigne cultivée Vitis vinifera est un des fruits les plus cultivés au monde.",
                calories = 90
                },
                new Ingredient
                {
                id = "salade",
                name = "Salade",
                isAvailable = true,
                picture = "salade.jpg",
                CategoryId = categories.Find(s => s.id == "vegetable").id,
                description = "La salade est un terme générique désignant en jardinage et horticulture diverses sortes de feuilles, c'est-à-dire de plantes potagères dont les feuilles, consommées crues, entrent dans la composition d'un mets froid dont elles ont pris le nom, la « salade », sous-entendu « salade verte ». Les salades sont des plantes angiospermes.",
                calories = 25
                },
                new Ingredient
                {
                id = "saumon",
                name = "Saumon",
                isAvailable = true,
                picture = "saumon.jpg",
                CategoryId = categories.Find(s => s.id == "fish").id,
                description = "Presque tous les saumons remontent les rivières vers les sources pour aller pondre (anadromie). La plupart des adultes meurent après la ponte. Après l'éclosion en eau douce, les jeunes migrent vers l'océan jusqu'à leur maturité sexuelle.",
                calories = 250
                },
                new Ingredient
                {
                id = "thon",
                name = "Thon",
                isAvailable = true,
                picture = "thon.jpg",
                CategoryId = categories.Find(s => s.id == "fish").id,
                description = "Les thons sont des poissons océaniques de la famille des scombridés : thons rouges, thon blanc – ou germon –, thon albacore, thon patudo et thon listao. Ces trois derniers sont des thons tropicaux.",
                calories = 180
                },
                new Ingredient
                {
                id = "toast",
                name = "Toast",
                isAvailable = true,
                picture = "toast.jpg",
                CategoryId = categories.Find(s => s.id == "other").id,
                description = "Le pain grillé (également désigné par l'anglicisme toast, et anciennement par le terme rôtie) est du pain normalement coupé en tranches et bruni par exposition à la chaleur. Ce brunissement est dû à des réactions de Maillard.",
                calories = 250
                },
                new Ingredient
                {
                id = "vin-rouge",
                name = "Vin Rouge",
                isAvailable = true,
                picture = "vin-rouge.jpg",
                CategoryId = categories.Find(s => s.id == "alcohol").id,
                description = "Un vin rouge est obtenu par la fermentation du moût de raisins noirs en présence de la pellicule, des pépins et éventuellement de la rafle.",
                calories = 70
                }
            };

            ingredients.ForEach(s => context.Ingredients.AddOrUpdate(p => p.id, s));
            context.SaveChanges();

            var communautes = new List<Communaute>
            {
                new Communaute
                {
                    firstname = "Hetta",
                    surname = "Van Deventer",
                    email = "hetta@mail.com",
                    password = "c17engineering",
                    level = 1.2,
                    picture = "hetta-van-deventer.jpg",
                    city = "Brive la Gaillarde",
                    birth = new System.DateTime(1972, 01, 01),
                    bio = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Odio aspernatur fuga quisquam iusto, eum veniam vel cumque autem assumenda nulla illum accusamus, expedita animi quaerat temporibus saepe magnam, dolor minima."
                },
                 new Communaute
                {
                    firstname = "Alfredo",
                    surname = "Linguini",
                    email = "alfredo@mail.com",
                    password = "c17engineering",
                    level = 0,
                    picture = "alfredo-linguini.jpg",
                    city = "Dunkerque",
                    birth = new System.DateTime(1993, 01, 01),
                    bio = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Odio aspernatur fuga quisquam iusto, eum veniam vel cumque autem assumenda nulla illum accusamus, expedita animi quaerat temporibus saepe magnam, dolor minima."
                },
                  new Communaute
                {
                    firstname = "Jean",
                    surname = "Bonneau",
                    email = "jean@mail.com",
                    password = "c17engineering",
                    level = 0,
                    picture = "jean-bonneau.jpg",
                    city = "Marseille",
                    birth = new System.DateTime(1982, 01, 01),
                    bio = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Odio aspernatur fuga quisquam iusto, eum veniam vel cumque autem assumenda nulla illum accusamus, expedita animi quaerat temporibus saepe magnam, dolor minima."
                },
                    new Communaute
                {
                    firstname = "Rose",
                    surname = "Bihff",
                    email = "rose@mail.com",
                    password = "c17engineering",
                    level = 0,
                    picture = "rose-bihff.jpg",
                    city = "Melun",
                    birth = new System.DateTime(1957, 01, 01),
                    bio = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Odio aspernatur fuga quisquam iusto, eum veniam vel cumque autem assumenda nulla illum accusamus, expedita animi quaerat temporibus saepe magnam, dolor minima."
                },
                     new Communaute
                {
                    firstname = "Pierre",
                    surname = "Musarro",
                    email = "pierrem@mail.com",
                    password = "c17engineering",
                    level = 0,
                    picture = "pierrem.jpg",
                    city = "Napoli",
                    birth = new System.DateTime(1981, 01, 01),
                    bio = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Odio aspernatur fuga quisquam iusto, eum veniam vel cumque autem assumenda nulla illum accusamus, expedita animi quaerat temporibus saepe magnam, dolor minima."
                },
                      new Communaute
                {
                    firstname = "Jonathan",
                    surname = "Baher",
                    email = "jonathan@mail.com",
                    password = "c17engineering",
                    level = 0,
                    picture = "jonathan.jpg",
                    city = "Tunis",
                    birth = new System.DateTime(1980, 01, 01),
                    bio = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Odio aspernatur fuga quisquam iusto, eum veniam vel cumque autem assumenda nulla illum accusamus, expedita animi quaerat temporibus saepe magnam, dolor minima."
                },
                       new Communaute
                {
                    firstname = "Nicolas",
                    surname = "Bouscal",
                    email = "nicolas@mail.com",
                    password = "c17engineering",
                    level = 0,
                    picture = "nicolas.jpg",
                    city = "Dublin",
                    birth = new System.DateTime(1981, 01, 01),
                    bio = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Odio aspernatur fuga quisquam iusto, eum veniam vel cumque autem assumenda nulla illum accusamus, expedita animi quaerat temporibus saepe magnam, dolor minima."
                },
                         new Communaute
                {
                    firstname = "Alexandre",
                    surname = "Seed",
                    email = "alexandre@mail.com",
                    password = "c17engineering",
                    level = 0,
                    picture = "alexandre.jpg",
                    city = "Compiègne",
                    birth = new System.DateTime(1989, 01, 01),
                    bio = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Odio aspernatur fuga quisquam iusto, eum veniam vel cumque autem assumenda nulla illum accusamus, expedita animi quaerat temporibus saepe magnam, dolor minima."
                },
                          new Communaute
                {
                    firstname = "Amjed",
                    surname = "Chouhima",
                    email = "amjed@mail.com",
                    password = "c17engineering",
                    level = 0,
                    picture = "amjed.jpg",
                    city = "Tunis",
                    birth = new System.DateTime(1987, 01, 01),
                    bio = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Odio aspernatur fuga quisquam iusto, eum veniam vel cumque autem assumenda nulla illum accusamus, expedita animi quaerat temporibus saepe magnam, dolor minima."
                },
                             new Communaute
                {
                    firstname = "Bruno",
                    surname = "Schmedtki",
                    email = "bruno@mail.com",
                    password = "c17engineering",
                    level = 0,
                    picture = "bruno.jpg",
                    city = "Gardanne",
                    birth = new System.DateTime(1981, 01, 01),
                    bio = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Odio aspernatur fuga quisquam iusto, eum veniam vel cumque autem assumenda nulla illum accusamus, expedita animi quaerat temporibus saepe magnam, dolor minima."
                },
                           new Communaute
                {
                    firstname = "Baptiste",
                    surname = "Céppéro",
                    email = "baptiste@mail.com",
                    password = "c17engineering",
                    level = 0,
                    picture = "baptiste.jpg",
                    city = "Saint-Etienne",
                    birth = new System.DateTime(1990, 01, 01),
                    bio = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Odio aspernatur fuga quisquam iusto, eum veniam vel cumque autem assumenda nulla illum accusamus, expedita animi quaerat temporibus saepe magnam, dolor minima."
                },
                            new Communaute
                {
                    firstname = "Bénédicte",
                    surname = "Cestal",
                    email = "benedicte@mail.com",
                    password = "c17engineering",
                    level = 0,
                    picture = "benedicte.jpg",
                    city = "Montpellier",
                    birth = new System.DateTime(1981, 01, 01),
                    bio = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Odio aspernatur fuga quisquam iusto, eum veniam vel cumque autem assumenda nulla illum accusamus, expedita animi quaerat temporibus saepe magnam, dolor minima."
                },
                              new Communaute
                {
                    firstname = "Christophe",
                    surname = "Porseci",
                    email = "christophe@mail.com",
                    password = "c17engineering",
                    level = 0,
                    picture = "christophe.jpg",
                    city = "Metz",
                    birth = new System.DateTime(1979, 01, 01),
                    bio = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Odio aspernatur fuga quisquam iusto, eum veniam vel cumque autem assumenda nulla illum accusamus, expedita animi quaerat temporibus saepe magnam, dolor minima."
                },
                               new Communaute
                {
                    firstname = "Clémence",
                    surname = "Ailame",
                    email = "clemence@mail.com",
                    password = "c17engineering",
                    level = 0,
                    picture = "clemence.jpg",
                    city = "Viny",
                    birth = new System.DateTime(1991, 01, 01),
                    bio = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Odio aspernatur fuga quisquam iusto, eum veniam vel cumque autem assumenda nulla illum accusamus, expedita animi quaerat temporibus saepe magnam, dolor minima."
                },
                                new Communaute
                {
                    firstname = "Faysal",
                    surname = "Biou",
                    email = "faysal@mail.com",
                    password = "c17engineering",
                    level = 0,
                    picture = "faysal.jpg",
                    city = "Stockholm",
                    birth = new System.DateTime(1990, 01, 01),
                    bio = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Odio aspernatur fuga quisquam iusto, eum veniam vel cumque autem assumenda nulla illum accusamus, expedita animi quaerat temporibus saepe magnam, dolor minima."
                },
                                 new Communaute
                {
                    firstname = "Jill",
                    surname = "Gerve",
                    email = "jill@mail.com",
                    password = "c17engineering",
                    level = 0,
                    picture = "jill.jpg",
                    city = "Austin",
                    birth = new System.DateTime(1992, 01, 01),
                    bio = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Odio aspernatur fuga quisquam iusto, eum veniam vel cumque autem assumenda nulla illum accusamus, expedita animi quaerat temporibus saepe magnam, dolor minima."
                },
                                  new Communaute
                {
                    firstname = "Johanna",
                    surname = "Teiab",
                    email = "johanna@mail.com",
                    password = "c17engineering",
                    level = 0,
                    picture = "johanna.jpg",
                    city = "Neuilly-Sur-Seine",
                    birth = new System.DateTime(1981, 01, 01),
                    bio = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Odio aspernatur fuga quisquam iusto, eum veniam vel cumque autem assumenda nulla illum accusamus, expedita animi quaerat temporibus saepe magnam, dolor minima."
                },
                                   new Communaute
                {
                    firstname = "Oussama",
                    surname = "Mizaa",
                    email = "oussama@mail.com",
                    password = "c17engineering",
                    level = 0,
                    picture = "oussama.jpg",
                    city = "Essaouira",
                    birth = new System.DateTime(1987, 01, 01),
                    bio = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Odio aspernatur fuga quisquam iusto, eum veniam vel cumque autem assumenda nulla illum accusamus, expedita animi quaerat temporibus saepe magnam, dolor minima."
                },
                                    new Communaute
                {
                    firstname = "Pierre",
                    surname = "Heminla",
                    email = "pierreh@mail.com",
                    password = "c17engineering",
                    level = 0,
                    picture = "pierreh.jpg",
                    city = "Melun",
                    birth = new System.DateTime(1990, 01, 01),
                    bio = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Odio aspernatur fuga quisquam iusto, eum veniam vel cumque autem assumenda nulla illum accusamus, expedita animi quaerat temporibus saepe magnam, dolor minima."
                },
                                     new Communaute
                {
                    firstname = "Thomas",
                    surname = "Syre",
                    email = "thomas@mail.com",
                    password = "c17engineering",
                    level = 0,
                    picture = "thomas.jpg",
                    city = "San Francisco",
                    birth = new System.DateTime(1984, 01, 01),
                    bio = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Odio aspernatur fuga quisquam iusto, eum veniam vel cumque autem assumenda nulla illum accusamus, expedita animi quaerat temporibus saepe magnam, dolor minima."
                }
            };

            communautes.ForEach(s => context.Communautes.AddOrUpdate(p => p.email, s));
            context.SaveChanges();
            try
            {
                var recettes = new List<Recette>
            {
                new Recette
                {
                    id = "tarte-citron-meringue",
                    name = "Tarte citron meringué",
                    isAvailable = true,
                    picture = "tarte-citron-meringue.jpg",
                    calories = 460,
                    preparation = "PÂTE:<br />Blanchir les jaunes et le sucre au fouet et détendre le mélange avec un peu d'eau.<br />Mélanger au doigt la farine et le beurre coupé en petites parcelles pour obtenir une consistance sableuse et que tout le beurre soit absorbé (!!! Il faut faire vite pour que le mélange ne ramollisse pas trop!).<br />Verser au milieu de ce 'sable' le mélange liquide.<br />Incoporer au couteau les éléments rapidement sans leur donner de corps.<br />Former une boule avec les paumes et fraiser 1 ou 2 fois pour rendre la boule + homogène.<br />Foncez un moule de 25 cm de diamètre avec la pâte, garnissez la de papier sulfurisé et de haricots secs.<br />Faites cuire à blanc 20 à 25 mn, à 180°C, Th 6-7 . (NB après baisser le four à 120°C/150°C environ pour la meringue).<br />CRÈME AU CITRON :<br />Laver les citrons et en 'zester' 2.<br />Mettre les zestes très fins dans une casserole.<br />Presser les citrons et mettre le jus avec les zestes dans la casserole.<br />Verser le sucre et la Maïzena.<br />Remuer, et commencer à faire chauffer à feux doux.<br />Battre les oeufs dans un récipients séparé.<br />Une fois les oeufs battus, incorporer tout en remuant le jus de citron, le sucre, la Maïzena et les zestes.<br />Mettre à feu fort et continuer à remuer à l'aide d'un fouet.<br />Le mélange va commencer à s'épaissir.<br />Attention de toujours remuer lorsque les oeufs sont ajoutés, car la crème de citron pourrait brûler.<br />Oter du feux et verser l'appareil sur le fond de tarte cuit.<br />MERINGUE :<br />Monter les blancs en neige avec une pincée de sel.<br />Quand ils commencent à être fermes, ajouter le sucre puis la levure.<br />Mixer jusqu'à ce que la neige soit ferme.<br />Recouvrir avec les blancs en neige et napper. Cuire à four doux (120°C/150°C) juqu'à ce que la meringue dore (10 mn)",
                    average = 3,
                    creation = DateTime.Now,
                    ChiefId = communautes.Find(p => p.firstname == "Hetta").id,
                },
                    new Recette
                {
                    id = "cake-jambon-olive",
                    name = "Cake au jambon et aux olives",
                    isAvailable = true,
                    picture = "cake-jambon-olive.jpg",
                    calories = 330,
                    preparation = "Couper les olives en rondelles.<br />Couper le jambon en morceaux. Verser les oeufs dans la farine et mélanger.<br />Ajouter le lait et l'huile puis mélanger.<br />Ajouter le jambon, les olives et le gruyère puis mélanger. Ajouter la levure et, pour ne pas changer, mélanger. :)<br />Mettre le tout dans un plat à cake au préalable beurré et placer dans un four chaud à thermostat 6 (180°C) pendant 45 min.",
                    average = 0,
                    creation = DateTime.Now,
                    ChiefId = 2,
                },
                     new Recette
                {
                    id = "saumon-echalotte",
                    name = "Saumon à l'échalotte",
                    isAvailable = true,
                    picture = "saumon-echalotte.jpg",
                    calories = 320,
                    preparation = "Mettre les échalotes avec le beurre dans une poêle. Mettre les pavés de saumon quand les échalotes sont translucides, saler légèrement.<br />Quand le saumon est cuit, le réserver dans une assiette. Déglacer les échalotes cuites avec le vinaigre balsamique coupé avec un peu d'eau.<br />Ajouter la pointe de moutarde. Faire mijoter 2-3 mn puis ajouter la crème.<br />Remettre les pavés de saumon dans la poêle juste avant de servir afin de les rechauffer.<br />Miam, Miam... Servir avec du riz ou, pourquoi pas, du chou romanesco!",
                    average = 0,
                    creation = DateTime.Now,
                    ChiefId = 3,
                },
                      new Recette
                {
                    id = "salade-de-fruit-granite",
                    name = "Salade de fruits au granité citron",
                    isAvailable = true,
                    picture = "salade-de-fruit-granite.jpg",
                    calories = 400,
                    preparation = "Commencez par préparer le granité. Placez le presse-agrumes sur la Kitchen Machine et pressez les citrons. Versez le jus obtenu dans le bol du robot, ajoutez le sucre et mélangez jusqu'à ce que le sucre soit dissout. Incorporez les feuilles de menthe écrasées et l'eau pétillante. Placez au congélateur toute une nuit.<br />Le jour J, lavez les fruits rouges. Egrappez les groseilles, dénoyautez les cerises puis coupez ces dernières et les fraises en quatre. Regroupez-les dans un saladier pour les mélanger puis répartissez-les dans des coupes.<br />Juste avant d'apporter à table, munissez-vous d'une fourchette et grattez le granité avant de le disposer sur les fruits.",
                    average = 0,
                    creation = DateTime.Now,
                    ChiefId = 1,
                },
                      new Recette
                {
                    id = "tajine-de-poulet",
                    name = "Tajine de poulet",
                    isAvailable = true,
                    picture = "tajine-de-poulet.jpg",
                    calories = 180,
                    preparation = "Faire revenir le poulet à feu moyen pour qu'il soit un peu doré.<br />Pendant ce temps, peler et couper les légumes : couper les carottes en 2 , puis dans le sens de la longueur. Idem pour les courgettes. Couper les oignons en lamelles et les pommes de terres en 4.<br />Mettre les légumes avec le poulet, rajouter les épices à tajine et le cumin. Mettez également un peu d'eau (3/4 verre d'eau).<br />Laisser cuire environ 1 heure et voilà, c'est prêt !",
                    average = 3,
                    creation = DateTime.Now,
                    ChiefId = 1,
                }
                };
                recettes.ForEach(s => context.Recettes.AddOrUpdate(p => p.id, s));
                context.SaveChanges();

                var ingredientsRecette = new List<IngredientRecette>
                {
                    new IngredientRecette
                    {
                        ingredientId = "sucre",
                        recetteId= "tarte-citron-meringue"
                    },
                    new IngredientRecette
                    {
                        ingredientId = "farine",
                        recetteId= "tarte-citron-meringue"
                    },
                    new IngredientRecette
                    {
                        ingredientId = "oeuf",
                        recetteId= "tarte-citron-meringue"
                    },
                    new IngredientRecette
                    {
                        ingredientId = "citron",
                        recetteId= "tarte-citron-meringue"
                    },
                    new IngredientRecette
                    {
                        ingredientId = "jambon",
                        recetteId= "cake-jambon-olive"
                    },
                     new IngredientRecette
                    {
                        ingredientId = "oeuf",
                        recetteId= "cake-jambon-olive"
                    },
                      new IngredientRecette
                    {
                        ingredientId = "farine",
                        recetteId= "cake-jambon-olive"
                    },
                       new IngredientRecette
                    {
                        ingredientId = "olives",
                        recetteId= "cake-jambon-olive"
                    },
                        new IngredientRecette
                    {
                        ingredientId = "gruyere",
                        recetteId= "cake-jambon-olive"
                    },
                         new IngredientRecette
                    {
                        ingredientId = "huile-tournesol",
                        recetteId= "cake-jambon-olive"
                    },
                         new IngredientRecette
                    {
                        ingredientId = "lait",
                        recetteId= "cake-jambon-olive"
                    },
                         new IngredientRecette
                    {
                        ingredientId = "saumon",
                        recetteId= "saumon-echalotte"
                    },
                         new IngredientRecette
                    {
                        ingredientId = "echalotte",
                        recetteId= "saumon-echalotte"
                    },
                         new IngredientRecette
                    {
                        ingredientId = "creme",
                        recetteId= "saumon-echalotte"
                    },
                          new IngredientRecette
                    {
                        ingredientId = "pomme",
                        recetteId= "salade-de-fruit-granite"
                    },
                          new IngredientRecette
                    {
                        ingredientId = "poire",
                        recetteId= "salade-de-fruit-granite"
                    },
                          new IngredientRecette
                    {
                        ingredientId = "fraise",
                        recetteId= "salade-de-fruit-granite"
                    },
                          new IngredientRecette
                    {
                        ingredientId = "banane",
                        recetteId= "salade-de-fruit-granite"
                    },
                          new IngredientRecette
                    {
                        ingredientId = "kiwi",
                        recetteId= "salade-de-fruit-granite"
                    },
                          new IngredientRecette
                    {
                        ingredientId = "glace",
                        recetteId= "salade-de-fruit-granite"
                    },
                          new IngredientRecette
                    {
                        ingredientId = "citron-vert",
                        recetteId= "salade-de-fruit-granite"
                    },
                          new IngredientRecette
                    {
                        ingredientId = "citron",
                        recetteId= "salade-de-fruit-granite"
                    },
                          new IngredientRecette
                    {
                        ingredientId = "sucre",
                        recetteId= "salade-de-fruit-granite"
                    },
                          new IngredientRecette
                    {
                        ingredientId = "poulet",
                        recetteId= "tajine-de-poulet"
                    },
                           new IngredientRecette
                    {
                        ingredientId = "citron",
                        recetteId= "tajine-de-poulet"
                    },
                            new IngredientRecette
                    {
                        ingredientId = "tomate",
                        recetteId= "tajine-de-poulet"
                    },
                             new IngredientRecette
                    {
                        ingredientId = "carotte",
                        recetteId= "tajine-de-poulet"
                    },
                              new IngredientRecette
                    {
                        ingredientId = "pomme-de-terre",
                        recetteId= "tajine-de-poulet"
                    }
                };
                ingredientsRecette.ForEach(s => context.IngredientReccettes.AddOrUpdate(p => new { p.ingredientId, p.recetteId }, s));
                context.SaveChanges();

                var commentaireRecette = new List<CommunauteRecette>
                {
                    new CommunauteRecette
                    {
                        recetteId ="tarte-citron-meringue",
                        communauteId = 11,
                        title = "Miam miam miaouuu",
                        mark = 4,
                        comment ="Franchement cette NgRecette, c’est de la bombe. Le genre de saveurs qui t’éveillent les papilles, t’as vu ! Dis woula, j’ai kiffé"
                    },
                    new CommunauteRecette
                    {
                        recetteId ="tarte-citron-meringue",
                        communauteId = 8,
                        title = "Ca pique !",
                        mark = 2,
                        comment ="Quelqu'un a mis du piment dans ma crème, j'ai passé mon dimanche au toilettes. Sinon, tout va bien.."
                    },
                    new CommunauteRecette
                    {
                        recetteId ="tajine-de-poulet",
                        communauteId = 6,
                        title = "On y est presque",
                        mark = 3,
                        comment ="Une petite tranche de jambon au milieu de tout ça serait la bienvenue"
                    }
                };
                commentaireRecette.ForEach(s => context.CommunauteRecettes.AddOrUpdate(p => new { p.recetteId, p.communauteId }, s));
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    using (StreamWriter _testData = new StreamWriter("C:\\Users\\C17 Developer\\Documents\\entity_data_log.txt"))
                    {
                        _testData.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            _testData.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                }
                throw;
            }
        }
    }
}
