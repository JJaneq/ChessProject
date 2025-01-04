Możliwe pola już wyświetlają się poprawnie, dodałem sprawdzanie czy jest szach.
Próbowałem zablokować możliwość poruszania figur w taki sposób by wystawiać własnego króla na szach
No i na razie wyszła mi metoda w Piece, która tak często odowołuje się do sprawdzania pól ataku przeciwnika, że zabija program.
Na razie nie mam pomysłu jak do tego sensowniej podejść, bo sprawdzanie stanu całej planszy dla każdego możliwego ruchu wydaje się być bardzo złym pomysłem

Ochraniane pola na które nie może wejsc król

Dodałem jedynie podstawowe ruchy i bicia figur

Skończyłem na dodaniu poruszania się pionków. W klasach innych rodzai pionków są metody GetPossibleMoves, w których dodając logikę poruszania się powinny one działać poprawnie po dodaniu ich w BoardGraphics.DrawPieces.
Zacząłem robić HideMoves i ShowMoves ale coś nie chce mi tego wyświetlać - jakoś jutro to ogarnę
Robiłem to na Riderze, ale z tego co sprawdzałem bez problemu odpala mi się i kompiluje w Visualu 2022
