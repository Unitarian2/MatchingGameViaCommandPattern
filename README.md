# MatchingGameViaCommandPattern
Command Pattern kullanılarak geliştirilmiş basit bir eşleştirme oyununu içeren repo'dur.<br>


---Command Classes---<br>
ICommand.cs => Oluşturulan her yeni Command class'ı bu interface'i implemente etmelidir. Ortak methodları içerir.<br>
CommandInvoker.cs => Command listesinin tutulduğu sınıftır. Oluşturulan her yeni Command class'ı, bir command'i Execute etmek, bir önceki command'e dönmek, command geçmişini almak ve son execute edilen command'i almak için bu sınıfı kullanır.<br>
SwapCommand.cs => Bu prototip için oluşturulmuş, iki objenin konumunu swap etmek için kullanılan bir command'dir. IconSwapper sınıfı üzerinden command swap işlemlerini gerçekleştirir. HistoryUIHandler üzerinden UI günceller.<br><br>

---Gameplay Classes---<br>
GameBoardSetupManager.cs => iconElementsList içerisindeki her IconSwappable nesnesine rastgele bir icon yüklemesi yapar. Masanın oyun başladığındaki kurulma işlemlerini gerçekleştirir.<br><br>

---GameManager.cs---<br>
GameManager methodları açıklaması aşağıdaki gibidir:<br>
Init => Masadaki tüm hücreleri initialize eder ilk ayarlamaları yapar.<br>
FillElementData => GameBoardSetupManager'ı kullanarak masayı kurar. Bu kurulum bir IconSwappable listesi döndürür. Bu liste üzerinden tüm hücrelerin yüklemesini yapar.<br>
InitializeElements => Tüm hücreleri seçime hazır hale getirir.<br>
StartGameValidationProcess => Bu method çalıştığında mevcut masadaki hücreleri kontrol ederek, eşleşen ikonlara sahip hücreleri yokeder ve yerine ikonlar spawn eder.<br><br>

