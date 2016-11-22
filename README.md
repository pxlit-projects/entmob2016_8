# entmob2016_8
## Installation
1. Install and run a local SQL server (eg. XAMP)
2. Create database entmob and database entmobtest using SQL/entmob.sql
3. Install and run a local ActiveMQ server (http://activemq.apache.org/download.html)
4. Add References to Xamarin app
5. Create a wifi hotspot on PC to connect to with your mobile device running the Xamarin app

Login Credentials admin: 

userid: 7

password: koen
## Groepsleden
- Koen Castermans
- Jasper Szkudlarski
- Stephane Oris
- Brecht Morrhey


## Concept
We gaan de sensor aan een headset hangen en aan de hand van de motion sensors detecteren wanneer de headset wordt opgezet en neergelegd. Met deze informatie zien we twee mogelijke toepassingen. De eerste is eerder voor particulier gebruik en houdt in dat de pc van de gebruiker automatisch vergrendeld wordt en dat alle social media toepassingen op "Away" worden gezet wanneer hij de headset neerlegt. Het omgekeerde gebeurt wanneer hij de headset terug opneemt.

Voor de tweede toepassingen kijken we naar een professionele context zoals een callcenter. Men kan de productiviteit van de werknemers meten door na te gaan wanneer ze hun headset ophebben. We kunnen ook nagaan wanneer ze effectief aan het bellen zijn door geluid te detecteren met de microfoon.We zijn nog niet zeker of dit de microfoon van de Sensortag of van de smartphone zal zijn.
Elke werknemer zal een app op zijn smartphone hebben die verbonden is met de Sensortag. De werknemers krijgen elk unieke inlog gegevens zodat de prestatie van elke werknemer apart gemeten kan worden. 

## Mobiele app
Deze app gaat gebruikt worden om te connecteren met de sensortag zodat de benodigde data verzameld kan worden. Deze app zal ook via de REST API data doorsturen naar de back end.

## UWP app
Deze app zal voor op de computer zijn. Hiermee kan de werkgever de prestaties van alle werknemers bekijken. Dit zal waarschijnlijk op een grafische manier zijn aan de hand van grafieken.

## Architectuur
![Architectuur schets](Architectuur afbeelding.PNG)

Van de Xamarin app naar Spring zal de REST API vooral gebruikt worden om gegevens te uploaden. Elke werknemer zal zich ook moeten inloggen, dus deze gegevens zullen gecontroleerd worden via de REST API.

Bij de UWP app zal de REST API vooral gebruikt worden om gegevens af te halen om deze bijvoorbeeld te kunnen verwerken in grafieken. Dit kunnen gegevens zijn per werknemer of van alle werknemers.
