;#DropDB DecathalonScoringEasyTest

#Application DecathalonScoring.Win
#Application DecathalonScoring.Web
#IfDef DecathalonScoring.Win

*Action About...
 
*Action OK

#EndIf

#IfDef DecathalonScoring.Web
!Action Navigation(My Details)
#EndIf
