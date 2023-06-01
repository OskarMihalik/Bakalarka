# Bakalarka
 
Aby sme mohli testovať aplikáciu tak musíme mať všetko pripravené. Tu si opíšeme ako
spustiť potrebné veci ako Unity aplikáciu, node-red server a spustenie PLC s potrebným
projektom.

# PLC
Ako prvé bude nutné pripraviť PLC aby Node-red s ním vedel komunikovať. Na to budeme
potrebovať:
- Fyzický prístup k PLC a výrobnej linke
- Ethernet kábel na prepojenie PLC a počítača
34
Obr. 23: Ukážka ako jednoducho dokážeme na zavolanie metódy pohnúť objektom
- TIA Portal V15
Keď máme všetky potrebné veci môžme pomocou TiA Portal V15 nahrať projekt v
pričinku PLC do PLC.

# Node-red
Pre spustenie Node-red servera budete potrebovať nainštalovať Node-red z oficiálneho
stránky a postupovať podľa inštalačných inštrukcií v https://nodered.org/docs/getting-
started/windows.
Po nainštalovaní Node-red potrebujeme spustiť Node-red cez konzolu pomocou príkazu
node-red. Mali by ste vidieť niečo takéto ako Obr. 24. Po spustení môžeme ísť na url
http://127.0.0.1:1880/ čo nám otvorí Node-red prostredie. V Node-red prostredí budeme
musieť importnúť náš flow, ktorý je uložený v PLC-node-red.json. V pravom hornom rohu
stlačíme hamburger menu, kde sa nám zobrazí menu s možnosťami, tu vyberieme možnosť
import a vyberieme súbor PLC-node-red.json. Po stlačení deploy v pravom hornom rohu
zistíme, že nám chýbajú knižnice:
- node-red-contrib-aedes
- node-red-contrib-s7
- node-red-contrib-s7comm

Nainštalujeme ich pomocou kliknutia na hamburger menu v pravom hornom rohu kde
vyberieme Manage pallete.

# Spustenie Unity aplikácie
Pre spustenie aplikácie treba nainštalovať Unity verziu 2020.3.33f1, aplikácia môže fungovať
aj na iných verziách Unity ale nieje to zaručené.
V Unity treba zmeniť jedno nastavenie aby sme sa mohli pripojiť na Node-red server. V
objektoch treba nájsť Managers a jeho dieťa obsahuje M2MqttManager. v M2MqttManager
nastavíme broker adress podľa IPv4 adresy a port nastavíme podľa Node-red.
Po spustení Unity projektu a úspešnom rozpoznaní výrobnej linky ak sme náhodou
nezadali správny port tak nám vybehne panel, kde môžme nastaviť inú adresu a port. Pri
správnom nastavení môžme znova vyskúšať naskenovať výrobnú linku
