# MatchingGameViaCommandPattern
Command Pattern kullanılarak geliştirilmiş basit bir eşleştirme oyununu içeren repo'dur.<br>


---Command Classes---<br>
ICommand.cs => Oluşturulan her yeni Command class'ı bu interface'i implemente etmelidir. Ortak methodları içerir.
CommandInvoker.cs => Command listesinin tutulduğu sınıftır. Oluşturulan her yeni Command class'ı, bir command'i Execute etmek, bir önceki command'e dönmek, command geçmişini almak ve son execute edilen command'i almak için bu sınıfı kullanır.


