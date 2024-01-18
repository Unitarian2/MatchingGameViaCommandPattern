# MatchingGameViaCommandPattern
Command Pattern kullanılarak geliştirilmiş basit bir eşleştirme oyununu içeren repo'dur.<br>


---Command Classes---<br>
<b>ICommand.cs =></b> Oluşturulan her yeni Command class'ı bu interface'i implemente etmelidir. Ortak methodları içerir.<br>
<b>CommandInvoker.cs =></b> Command listesinin tutulduğu sınıftır. Oluşturulan her yeni Command class'ı, bir command'i Execute etmek, bir önceki command'e dönmek, command geçmişini almak ve son execute edilen command'i almak için bu sınıfı kullanır.<br>
<b>SwapCommand.cs =></b> Bu prototip için oluşturulmuş, iki objenin konumunu swap etmek için kullanılan bir command'dir. IconSwapper sınıfı üzerinden command swap işlemlerini gerçekleştirir. HistoryUIHandler üzerinden UI günceller.<br><br>

---Gameplay Classes---<br>
<b>GameBoardSetupManager.cs =></b> iconElementsList içerisindeki her IconSwappable nesnesine rastgele bir icon yüklemesi yapar. Masanın oyun başladığındaki kurulma işlemlerini gerçekleştirir.<br>
<b>IconRespawnHandler.cs =></b> Bu sınıf verilen hücrelere yeni rastgele ikonlar spawn eder. respawnCompletedCallback Action'ı ile bu işlemin bitişi tespit edilebilir.<br>
<b>IconSwappable.cs =></b> Masadaki her hücrenin Gameobject'inde bu sınıf eklidir. Bir hücre için frontend tarafında gerekli tüm data ve methodlar bu sınıf içerisindedir. Hangi hücrede hangi icon tipi olduğu IconIndex üzerinden belirlenir.<br>
<b>IconSwapper.cs =></b> Verilen iki hücrenin icon'larını yer değiştirir. Bunu yaparken önce görsel olarak konumların güncellenmesi animasyonunu çalıştırdıktan sonra,Horizontal Layout içerisinde childindex'ler üzerinden konumları da günceller. Swap sonrası geçerli eşleşme gerçekleşecekse GameManager içerisindeki StartGameValidationProcess methodunu çağırarak eşleşme sürecini başlatır.<br>
<b>InputManager.cs =></b> Oyuncu kontrollerini içerir. Masa üzerindeki hücrelerin seçimi işlemlerini gerçekleştirir. 2. hücre seçildiğinde swap işlemleri başlar. Swap işlemleri Command Pattern'e uygun olarak CommandInvoker üzerinden başlatılır.<br>
<b>SuccessValidationHandler.cs =></b> Eşleşme kurallarını içeren sınıftır. Bu sınıftan nesne oluştururken Consturctor'da masadaki hücrelerin bir listesi verilir. Bu sınıf, listeyi bir matrix'e çevirerek doğru eşleşmeleri tespit eder.

---GameManager.cs---<br>
GameManager methodları açıklaması aşağıdaki gibidir:<br>
<b>Init =></b> Masadaki tüm hücreleri initialize eder ilk ayarlamaları yapar.<br>
<b>FillElementData =></b> GameBoardSetupManager'ı kullanarak masayı kurar. Bu kurulum bir IconSwappable listesi döndürür. Bu liste üzerinden tüm hücrelerin yüklemesini yapar.<br>
<b>InitializeElements =></b> Tüm hücreleri seçime hazır hale getirir.<br>
<b>StartGameValidationProcess =></b> Bu method çalıştığında mevcut masadaki hücreleri kontrol ederek, eşleşen ikonlara sahip hücreleri yokeder ve yerine ikonlar spawn eder.<br><br>

---UI Classes---<br>
<b>HistoryUIHandler.cs =></b> CommandInvoker'dan execute edilen command'lerin bilgisini çekerek ekranın sağ tarafında bir command history gösterir. Undo yapıldığında isRemoval true olarak gönderilir ve böylece sadece başarılı swap'ların bir history'si ekranda kalmış olur.<br>
<b>SwapCommandElementUI.cs =></b> Vertical layout'ta HistoryUIHandler'ın ekleyip çıkardığı UI element'lerin bilgisini tutan sınıftır.

