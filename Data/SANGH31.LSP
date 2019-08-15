;;-------------------------------------------------------
;; CONSTRUCTED by hangdeok 2001.4.19
;;	2004. 1.20 막대그래프 추가	
;;  2004. 7.26 부분 콘크리트 보호공드로잉 수정
;;  2004. 8.10 slope 표기 옵션수정 끄려면 (setq DRAWSLOPE 1)에서 1을 0으로
;;-------------------------------------------------------
(defun c:sangh() 
   (setq DRAWSLOPE 0)
   (setvar "CMDECHO" 0)
   (setvar "BLIPMODE" 0)
   (setvar "DIMZIN" 0)
   (command "LINETYPE" "S" "BYLAYER" "")
   (command "COLOR" "BYLAYER")
   (command "OSNAP" "OFF")
   (command "LTSCALE" 5.0)
   (if (< (existarx "geomcal.arx") 0)
	   (arxload "geomcal")
	)
;;-------------------------------------------------------
;; open file
;;-------------------------------------------------------
   (setq rf (getstring "\nFile to read (including extension): "))
   (setq rfa (findfile rf))
   (if rfa
     (progn
       (if (null (setq infile (open rfa "r")))
         (princ "\n\tFile found")
       )
     )
     (if (/= (substr rf (- (strlen rf) 3) 1) ".")
       (princ "\nFile not found.  Extension may be missing.")
       (princ "\nFile not found. ")
     )
   )

;;-------------------------------------------------------
;; get value
;;-------------------------------------------------------

   (setq ctr 0)
   (setq enp -99)

;;-------------------------------------------------------
;; read scale
;;-------------------------------------------------------

   (setq lineread (read-line infile)) ;; title read
   (setq lineread (read-line infile))

   (setq scale (atof  (substr lineread  1 10)))
   (setq sangsu (atof  (substr lineread  11 10)))
   (setq scale (/ 1000.0 scale))
   (setq tscale (* scale 1.0))
   (setq RIGHT 0)
   
;;-------------------------------------------------------
;; data read
;;-------------------------------------------------------
   (setq noch 0)
   (setq Ncol 0)
   (setq Nrow 0)
       (if (> HRZNUM 0)
	  (if (> RIGHT 0)
             (progn
;		(setq Ncol (+ Ncol 1))	
	     )
	     (progn
;		(setq Nrow (cal "HRZNUM/"))
	     )
          )
       )	

   (while (/= (setq noch (atoi (substr (setq lineread (read-line infile)) 1 3))) -99)
       (setq nochain (substr lineread 1 19))
       (setq HRZNUM (atof (substr lineread 20 7)))
       (setq Lnuga (atof (substr lineread 26 10)))
       (if (> RIGHT 0)
         (setq Ncol (+ Ncol 1))	
         (setq Nrow (+ Nrow 1))	
       )

       (setq dist 	(atof (substr lineread 19 7)))
       (setq gh 	(atof (substr lineread 36 7)))
       (setq INV 	(atof (substr lineread 43 7)))
       (setq LINENAME 	(substr lineread 50 20))
       (setq DIA 	(atof (substr lineread 70 5)))
       (setq BR	 	(atof (substr lineread 75 5)))
       (setq type 	(atof (substr lineread 80 3)))
       (setq T1 	(atof (substr lineread 84 5)))
       (setq SLOPE 	(atof (substr lineread 90 10)))
       (setq Bcut 	(atof (substr lineread 100 10)))
       (setq Hcut 	(atof (substr lineread 110 10)))
       (setq manwork 	(atof (substr lineread 120 10)))
       (setq sand 	(atof (substr lineread 130 10)))
       (setq concA 	(atof (substr lineread 140 10)))
       (setq concB 	(atof (substr lineread 150 10)))
       (setq humanity 	(atof (substr lineread 160 10)))
       (setq concrete 	(atof (substr lineread 170 10)))
       (setq asphalt1 	(atof (substr lineread 180 10)))
       (setq asphalt2 	(atof (substr lineread 190 10)))
       (setq complay 	(atof (substr lineread 200 10)))
       (setq mixlay 	(atof (substr lineread 210 10)))
       ;(setq mixlay 	(substr lineread 220 10))
       ;(setq mixlay 	(substr lineread 230 10))
       (setq area1 	(atof (substr lineread 240 10)))
       (setq area2 	(atof (substr lineread 250 10)))
       (setq area3 	(atof (substr lineread 260 10)))
       (setq area4 	(atof (substr lineread 270 10)))
       (setq area5 	(atof (substr lineread 280 10)))
       (setq area6 	(atof (substr lineread 290 10)))
       (setq area7 	(atof (substr lineread 300 10)))
       (setq area8 	(atof (substr lineread 310 10)))
       (setq area9 	(atof (substr lineread 320 10)))
       (setq area10 	(atof (substr lineread 330 10)))
       (setq area11 	(atof (substr lineread 340 10)))
       (setq T2     	(atof (substr lineread 350 10)))
       (setq T3     	(atof (substr lineread 360 10)))
       (setq T4     	(atof (substr lineread 370 10)))
       (setq B     	(atof (substr lineread 380 10)))
       (setq H     	(atof (substr lineread 390 10)))
       (setq DIR   	(atof (substr lineread 420 10))); 1:LEFT  2:RIGHT
       (setq B2    	(atof (substr lineread 430 10)))
       (setq INV2  	(atof (substr lineread 440 10)))
       (setq DIA2  	(atof (substr lineread 450 10)))
	(setq boxscale 10)
	(setq tboxscale 10)
	(setq slope2 0.3)
	(setq H2 (cal "H+(INV-INV2)"))
	(setq COMP (cal "humanity+concrete+asphalt1+asphalt2"))
	(if (> concA 0)	
		(if (> concA 360)
			(setq concH (cal "DIA+Hcut+concA-360"))							; concrete H calculation
			(setq concH (+ (angl2h DIA concA ) Hcut))
		)
		(setq concH 0)
	)
	;(princ (strcat "====>" (rtos (angl2h DIA concA ) 2 2) "=>"))


;;--------------------------------------------------------
;;##################  CALCULATING AREA  ##################
;;--------------------------------------------------------
(if (<= (cal "area1+area2+area3+area4") 0)
   (progn
	(setq H (cal "GH-INV+Hcut"))
	(setq B (cal "DIA+Bcut*2+SLOPE*(H-COMP)*2"))
	(setq area5 0 area6 0 area7 0 area8 0 area9 0 area10 0 area11 0)
	(setq area1 (cal "(H-COMP)*(B+DIA+Bcut*2)*0.5"))
	(if(< manwork 0)
		(setq area2 (cal "(Hcut+DIA)*((DIA+Bcut*2)+SLOPE*(Hcut+DIA))"))
		(setq area2 (cal "(Hcut+DIA+manwork)*((DIA+Bcut*2)+SLOPE*(Hcut+DIA+manwork))"))
	)
	(if (> sand 0)
	   (progn
		(setq area5 (cal "sand*((DIA+Bcut*2)+SLOPE*sand)"))
		(if (> sand Hcut)
			(if (> sand (+ Hcut DIA))
				(setq area5 (cal "area5-DIA*DIA*pi/4"))
				(progn
				(setq angl (h2angl DIA (- sand Hcut)))
				(setq area5 (cal "area5-(d2r(angl)-sin(r2d(angl)))*DIA*DIA/8"))
				)
			)
		)
	   );end progn
	);end if sand
	(if (> concH 0)
		(if (> concB 0)
		   (progn
			(setq area11 (cal "concH*(concB*2+DIA)"))
			(setq area10 (cal "concH*2"))
			(if (> concH Hcut)
				(if (> concH (+ Hcut DIA))
					(setq area11 (cal"area11-DIA*DIA*pi/4"))
					(progn
					(setq angl (h2angl DIA (- concH Hcut)))
					(setq area11 (cal "area11-(1/8)*(d2r(angl)-sin(angl))*DIA*DIA"))
					)
				)
			)
		   );end progn
		   (progn
			(setq area11 (cal "concH*((DIA+Bcut*2)+SLOPE*concH)"))
			(if (> concH Hcut)
				(if (> concH (+ Hcut DIA))
					(setq area11 (cal "area11-DIA*DIA*pi/4"))
					(progn
					(setq angl (h2angl DIA (- concH Hcut)))
					(setq area11 (cal "area11-(1/8)*(d2r(angl)-sin(angl))*DIA*DIA"))
					)
				)
			)
		   );end progn
		);end if concB>0
	); end if concH>0
	(setq area2 (cal "area2-DIA*DIA*pi/4-area11-area5"))
	(if (< manwork 0)
		(setq machwork (cal "H-COMP-complay-mixlay-Hcut-DIA"))
		(setq machwork (cal "H-COMP-complay-mixlay-Hcut-DIA-manwork"))
	)
	(setq area3 (cal "machwork*(B-SLOPE*(complay+mixlay)*2-SLOPE*machwork)"))
	(if (< manwork 0)
	   (progn
		(setq area3 (+ area3 area2))
		(setq area2 0)
	  )
	)
	(setq area4 (cal "area1-area2-area3"))
	(if (> COMP 0)
	   (progn
		(setq area6 (cal "COMP*B"))
		(setq area7 B)
	   )
	)
	(if (> complay 0)
	   (progn
		(setq area8 (cal "complay*(B-SLOPE*complay)"))
		(setq area9 (cal "mixlay*(B-SLOPE*(complay*2+mixlay))"))
	   )
	)
   );END PROGN
);END IF MANUAL CALCULATION
		
;;-------------------------------------------------------
;;     define SCALE BAR
;;-------------------------------------------------------
	(command "LAYER" "SET" "CHISU" "")
	(setq SCLINE 0.5)
	(setq LOW (cal "round(INV-Hcut-1.5)" ))	
	(setq HIGH (cal "round(GH+1.5)" ))
   	(setq xx (cal "-boxscale*3.0" ))
  	(setq yy (cal "scale*(LOW-GH)" ))
   	(setq p1 (list xx yy))
	(setq p2 (polar p1 (dtor 90) (cal "scale*(HIGH-LOW)")))
  	(command "PLINE" p1 "w" "0" "0" p2 "")
  	(command "PLINE" (polar p1 0 (cal "scale*0.05")) "w" "0" "0" (polar p2 0 (cal "scale*0.05")) "")

	(setq CHI LOW)
	(setq p3 p1  blip 0)
	(while (<= CHI HIGH)
	  	(setq yy (cal "scale*(CHI-GH)" ))
	   	(setq pc (list xx yy))
		(if (> blip 0) (progn
			(command "SOLID" pc (polar pc 0 (cal "scale*0.05")) p3 (polar p3 0 (cal "scale*0.05")) "")
			(setq blip 0)
			); end progn
			(setq blip 1)
			); end if
		(setq p2 (polar pc (dtor 0) (cal "scale*0.3")))
	  	(command "PLINE" pc "w" "0" "0" p2 "")
		(setq str (strcat "" (rtos CHI 2 1)))
		(setq p2 (polar pc (dtor 45) (cal "scale*0.2")))
		(command "TEXT" p2 (* 0.15 tboxscale) "0" str)
		(setq p3 pc)
		(setq CHI (+ CHI 1.0))
	);while


;;-------------------------------------------------------
;;     define ground line
;;-------------------------------------------------------
	
	(setq GND 0.5)
	(if (/= type 0)
	   (progn
		(setq Bsec (cal "T3*2+BR*type+T4*(type-1)"))
		(setq Hsec (cal "T1+DIA+T2"))
	   );progn end
	)	
       	(command "LAYER" "SET" "GUJO" "")			;draw ground
	(if (/= DIR 0)
	       	(setq xx (cal "scale*(2*GND+B+B2)" ))
	       	(setq xx (cal "scale*(2*GND+B)" ))
	)
       	(setq yy 0)
       	(setq p1 (list 0.0 0.0))
       	(setq p2 (list xx yy))
       	(command "LINE" p1 p2 "")
	(command "LAYER" "SET" "CHISU" "")
	(setq xx (/ xx 2))
       	(setq p1 (list xx 0.0))
	(setq p2 (polar p1  (dtor 90) (* 0.4 boxscale) ))
	(setq p3 (polar p2  0 (* 1.2 boxscale) ))
	(setq p4 (polar p1  (dtor 60) (* 0.2 boxscale) ))
	(setq p5 (polar p1  (dtor 120) (* 0.2 boxscale) ))
       	(command "PLINE" p1 "w" "0" "0" p4 p5 p1 p2 p3 "")
	(command "LAYER" "SET" "text" "")
	(setq p2 (polar p2  (dtor 90) (* 0.1 boxscale) ))
	(setq str (strcat "G.H.:" (rtos GH 2 2)))
	(command "TEXT" p2 (* 0.15 tboxscale) "0" str)
       	(command "LAYER" "SET" "CENTER" "")			;draw section mark
	(princ DIR)
	(if (/= DIR 0) 
	       	(setq xx (cal "scale*(2*GND+B+B2)" ))
	       	(setq xx (cal "scale*(2*GND+B)" ))
	)
       	(setq yy (cal "scale*GND"))
       	(setq p1 (list 0 yy))
       	(setq yy (cal "-scale*(GND+COMP+mixlay+complay)"))
       	(setq p2 (list 0 yy))
       	(command "LINE" p1 p2 "")
       	(setq yy (cal "scale*GND"))
       	(setq p1 (list xx yy))
       	(setq yy (cal "-scale*(GND+COMP+mixlay+complay)"))
       	(setq p2 (list xx yy))
       	(command "LINE" p1 p2 "")
	(command "LAYER" "SET" "TEXT" "")
	(setq p2 (list (+ xx (* 0.2 scale)) (* boxscale 0.2)))
	(if (> humanity 0)
		(command "TEXT" p2 (* 0.2 tboxscale) "0" "보도구간")
		(if (> concrete 0)
		   (progn
		      (if  (= concrete 0.07)
		      	(progn
			      	( if (= complay 0.15)
			      		( if (= sand 0.05)
			      			(command "TEXT" p2 (* 0.2 tboxscale) "0" "투수콘크리트구간") 
			      		)
			      	)
			      )
			      (progn   ;concrete가 0.7이 아니면
				      (if (> asphalt1 0)
				        (command "TEXT" p2 (* 0.2 tboxscale) "0" "ASP+CONC.포장구간") 
				      	(command "TEXT" p2 (* 0.2 tboxscale) "0" "CONC.포장구간") 
				      )							      
		      	 )
			   )   
			)
			(progn			;Concrete가 0보다 <= 으면서
				(if (> asphalt1 0)
				  (progn				  					  
				  	(if (= asphalt1  0.11)
				  		(progn
				  			(if  (= asphalt2 0.1)
				  				(command "TEXT" p2 (* 0.2 tboxscale) "0" "ASP.포장구간(국도)")				  		
				  			)
				  		)				  		
				  	)
				  	(command "TEXT" p2 (* 0.2 tboxscale) "0" "ASP.포장구간")  ;110이 아니면				  															
					)
				  (command "TEXT" p2 (* 0.2 tboxscale) "0" "비포장구간") ; asphalt1 <= 이면
				)
			)	
		)
	)

       	(command "LAYER" "SET" "STEEL" "")			;draw cutting line
       	(setq xx (cal "scale*GND" ))
       	(setq yy 0)
       	(setq p1 (list xx yy))
       	(setq yy (cal "scale*(-COMP)"))
       	(setq p5 (list xx yy))
	(if (/= DIR 0) 
	 (progn
	  (if (= DIR 1)
	   (progn
	       	(setq xx (cal "scale*(GND+SLOPE*(H-COMP))" ))
 	      	(setq yy (cal "scale*(-H)"))
  	     	(setq p2 (list xx yy))
		(setq xx (+ xx (cal "scale*B")))
 	      	(setq p3 (list xx yy))
		(setq p9 (polar p3 (dtor 180) (cal "scale*(slope2*abs(INV2-INV)/2)")))
		(if (< INV INV2)
			(setq p11 p3)
			(setq p11 (polar p3 (dtor 90) (cal "scale*(INV2-INV)")))
		)
		(setq p10 (polar p3 (dtor 90) (cal "scale*H")))
		(command "LAYER" "SET" "CENTER" "")
		(command "line" p11 p10 "")
		(command "LAYER" "SET" "STEEL" "")
		(setq p7 (polar p3 (dtor 0) (cal "scale*(slope2*abs(INV2-INV)/2)")))
		(setq p7 (polar p7 (dtor 90) (cal "scale*(INV2-INV)")))
		(setq p8 (polar p7 (dtor 0) (cal "scale*(B2-slope2*abs(INV2-INV)/2)")))
	       	(setq xx (+ xx (cal "scale*(B2+SLOPE*(H-COMP))")))
		(setq yy (+ yy (cal "scale*(H-COMP)")))
	   )
	   (progn
	       	(setq xx (cal "scale*(GND)" ))
 	      	(setq yy (cal "scale*(-H2)"))
  	     	(setq p2 (list xx yy))
		(setq xx (+ xx (cal "scale*B2")))
 	      	(setq p3 (list xx yy))
		(setq p9 (polar p3 (dtor 180) (cal "scale*(slope2*abs(INV2-INV)/2)")))
		(if (< INV2 INV)
			(setq p11 p3)
			(setq p11 (polar p3 (dtor 90) (cal "-scale*(INV2-INV)")))
		)
		(setq p10 (polar p3 (dtor 90) (cal "scale*H2")))
		(command "LAYER" "SET" "CENTER" "")
		(command "line" p11 p10 "")
		(command "LAYER" "SET" "STEEL" "")
		(setq p7 (polar p3 (dtor 0) (cal "scale*(slope2*abs(INV2-INV)/2)")))
		(setq p7 (polar p7 (dtor 90) (cal "-scale*(INV2-INV)")))
		(setq p8 (polar p7 (dtor 0) (cal "scale*(B-slope2*abs(INV2-INV)/2)")))
	       	(setq xx (+ xx (cal "scale*(B+SLOPE*(H-COMP))")))
		(setq yy (+ yy (cal "scale*(H-COMP)")))
	   );progn
	  );end if
	 );end progn
	 (progn
	  (setq xx (cal "scale*(GND+SLOPE*(H-COMP))" ))
 	  (setq yy (cal "scale*(-H)"))
  	  (setq p2 (list xx yy))
	  (if (= type 0)       
		(setq xx (+ xx (cal "scale*(Bcut*2+DIA)")))
	       	(setq xx (+ xx (cal "scale*(Bcut*2+Bsec)")))
	  )
 	  (setq p3 (list xx yy))
       	  (setq xx (+ xx (cal "scale*(SLOPE*(H-COMP))")))
          (setq yy (+ yy (cal "scale*(H-COMP)")))
	 )
	)
       	(setq p4 (list xx yy))
       	(setq p6 (list xx 0))
	(if (/= DIR 0)
	       	(command "PLINE" p1 "w" "0" "0" p5 p2 p9 p7 p8 p4 p6 "")
	       	(command "PLINE" p1 "w" "0" "0" p5 p2 p3 p4 p6 "")
	)
	(setq p9 (polar p1  (dtor 90) (* 0.8 boxscale) ))
	(if (= DIR 2)
		(setq str (strcat "B'=" (rtos B2 2 2)))
		(setq str (strcat "B=" (rtos B 2 2)))
	)
	(prompt " ")(princ str)
       	(command "DIM" "horizontal" p1 p6 p9 str "exit")
	(setq p7 p2)
	(setq p9 (polar p2  (dtor 180) (* 2.4 boxscale) ))
	(if (= DIR 2)
		(setq str (strcat "H'=" (rtos H2 2 2)))
		(setq str (strcat "H=" (rtos H 2 2)))
	)
       	(command "DIM" "vertical" (polar p1 (dtor 180) (* 0.5 boxscale)) (polar p7 (dtor 180) (* 0.5 boxscale)) p9 str "exit")	;*****CHECK
	(if (/= DIR 0) 
	   (progn
		(setq p9 (polar p6  (dtor 90) (* 0.8 boxscale) ))
		(if (= DIR 2)
			(setq str (strcat "B=" (rtos B 2 2)))
			(setq str (strcat "B'=" (rtos B2 2 2)))
		)
		(prompt " ")(princ str)
 	      	(command "DIM" "horizontal" p10 p6 p9 str "exit")
		(setq p9 (polar p6  (dtor 0) (* 1.2 boxscale) ))
		(if (= DIR 2)
			(setq str (strcat "H=" (rtos H 2 2)))
			(setq str (strcat "H'=" (rtos H2 2 2)))
		)
 	      	(command "DIM" "vertical" p6 p8 p9 str "exit")
		(setq p9 (polar p6  (dtor 90) (* 1.4 boxscale) ))
		(setq str (strcat "Bt=" (rtos (+ B B2) 2 2)))
		(prompt " ")(princ str)
 	      	(command "DIM" "horizontal" p1 p6 p9 str "exit")
	   )
	)
	
	(if (= SLOPE 0)
		(progn
	       	(command "LAYER" "SET" "GUJO" "")			;draw SK-pannel
   	    	(setq p1 (list (cal "scale*GND") 0) )
		(if (= DIR 2)
			(setq p2 (polar p1  (dtor 270) (cal "scale*(H2+0.1)") ))
			(setq p2 (polar p1  (dtor 270) (cal "scale*(H+0.1)") ))
		)
		(setq p3 (polar p2  (dtor 270) (cal "scale*0.1") ))
		(setq p3 (polar p3  (dtor 180) (cal "scale*0.1") ))
		(if (= DIR 2)
			(setq p4 (polar p3  (dtor 90) (cal "scale*(H2+0.2)") ))
			(setq p4 (polar p3  (dtor 90) (cal "scale*(H+0.2)") ))
		)
	       	(command "PLINE" p1 "w" "0" "0" p2 p3 p4 p1 "")
		(if (/= DIR 0)
		   (progn
	   	    	(setq p1 (list (cal "scale*(GND+B+B2)") 0) )
			(if (= DIR 2)
				(setq p2 (polar p1  (dtor 270) (cal "scale*(H+0.1)") ))
				(setq p2 (polar p1  (dtor 270) (cal "scale*(H2+0.1)") ))
			)
			(setq p3 (polar p2  (dtor 270) (cal "scale*0.1") ))
			(setq p3 (polar p3  (dtor 0) (cal "scale*0.1") ))
			(if (= DIR 2)
				(setq p4 (polar p3  (dtor 90) (cal "scale*(H+0.2)") ))
				(setq p4 (polar p3  (dtor 90) (cal "scale*(H2+0.2)") ))
			)
		   )
		   (progn
	   	    	(setq p1 (list (cal "scale*(GND+B)") 0) )
			(setq p2 (polar p1  (dtor 270) (cal "scale*(H+0.1)") ))
			(setq p3 (polar p2  (dtor 270) (cal "scale*0.1") ))
			(setq p3 (polar p3  (dtor 0) (cal "scale*0.1") ))
			(setq p4 (polar p3  (dtor 90) (cal "scale*(H+0.2)") ))
		   )
		)
	       	(command "PLINE" p1 "w" "0" "0" p2 p3 p4 p1 "")
		)
	)
       	
	(if (and (> SLOPE 0) (> 0 DRAWSLOPE))						;slope mark
		(progn
		(command "LAYER" "SET" "CHISU" "")
	       	(setq xx (cal "scale*GND" ))
   	    	(setq yy (cal "scale*(-H/2)"))
  	     	(setq p1 (list xx yy))
      	 	(setq yy (cal "yy-boxscale*GND"))
       		(setq p2 (list xx yy))
       		(setq xx (+ xx (cal "boxscale*SLOPE*GND")))
	       	(setq p3 (list xx yy))
     	  	(command "PLINE" p1 "w" "0" "0" p2 p3 "c")
		(command "LAYER" "SET" "TEXT" "")
	       	(setq xx (cal "scale*GND" ))
      	 	(setq yy (cal "yy+scale*GND/3"))
       		(setq p4 (list xx yy))
		(setq p4 (polar p4  (dtor 180) (* 0.2 boxscale) ))
		(setq p4 p1)
		(setq p4 (polar p4  (dtor 225) (* 0.4 boxscale) ))
		(command "TEXT" p4 (* 0.15 tboxscale) "0" 1)
	       	(setq xx (cal "scale*GND" ))
      	 	(setq yy (cal "-scale*(H/2+GND)"))
       		(setq p4 (list xx yy))
		(setq p4 (polar p4 (dtor 270) (* 0.2 boxscale) ))
		(setq p4 p3)
		(setq p4 (polar p4 (dtor 225) (* 0.4 boxscale) ))
		(setq str (rtos SLOPE 2 1))
		(command "TEXT" p4 (* 0.15 tboxscale) "0" str)
		)
	)
	(if (= type 0)
	   (progn
		(if (= DIR 2)
		  (progn
		       	(command "LAYER" "SET" "CHISU" "")			;draw 1 pipe
		      	(setq xx (cal "scale*(GND+B2/2)" ))
		     	(setq yy (cal "scale*(-H2+DIA2/2)"))
	 	   	(setq p1 (list xx yy))
	  	 	(setq yy (- yy (cal "scale*DIA2/2")))
		  )
		  (progn
		       	(command "LAYER" "SET" "PIPE" "")			;draw 1 pipe
		      	(setq xx (cal "scale*(GND+B/2)" ))
		     	(setq yy (cal "scale*(-H+Hcut+DIA/2)"))
	 	   	(setq p1 (list xx yy))
	  	 	(setq yy (- yy (cal "scale*DIA/2")))
		  )
		)
	  	(setq p2 (list xx yy))
	 	(command "CIRCLE" p1 p2)
		(command "LAYER" "SET" "CHISU" "")
 	      	(setq p1 p2)
		(setq p2 (polar p1  (dtor 270) (* 1.0 boxscale) ))
		(setq p3 (polar p2  (dtor 0)  (* 1.2 boxscale) ))
		(setq p4 (polar p1  (dtor 240) (* 0.2 boxscale) ))
		(setq p5 (polar p1  (dtor 300) (* 0.2 boxscale) ))
	      	(command "PLINE" p1 "w" "0" "0" p4 p5 p1 p2 p3 "")
		(setq p2 (polar p2  (dtor 45) (* 0.1 boxscale) ))
		(if (= DIR 2)
			(setq str (strcat "INV:" (rtos INV2 2 2)))
		   (progn
			(command "LAYER" "SET" "TEXT" "")
			(setq str (strcat "INV:" (rtos INV 2 2)))
		   )
		)
		(command "TEXT" p2 (* 0.15 tboxscale) "0" str)
		(if (/= DIR 0)
		   (progn
			(if (= DIR 2)	
			   (progn
			       	(command "LAYER" "SET" "PIPE" "")			;draw 2 pipe
 			      	(setq xx (cal "scale*(GND+B2+B/2)" ))
  			     	(setq yy (cal "scale*(-H+Hcut+DIA/2)"))
   			    	(setq p1 (list xx yy))
    			   	(setq yy (- yy (cal "scale*DIA/2")))
			   )
			   (progn
			       	(command "LAYER" "SET" "CHISU" "")			;draw 2 pipe
 			      	(setq xx (cal "scale*(GND+B+B2/2)" ))
  			     	(setq yy (cal "scale*(-H2+Hcut+DIA2/2)"))
   			    	(setq p1 (list xx yy))
    			   	(setq yy (- yy (cal "scale*DIA2/2")))
			   )
			)
     		  	(setq p2 (list xx yy))
      		 	(command "CIRCLE" p1 p2)
			(command "LAYER" "SET" "CHISU" "")
 		      	(setq p1 p2)
			(setq p2 (polar p1  (dtor 270) (* 1.0 boxscale) ))
			(setq p3 (polar p2  (dtor 0)  (* 1.2 boxscale) ))
			(setq p4 (polar p1  (dtor 240) (* 0.2 boxscale) ))
			(setq p5 (polar p1  (dtor 300) (* 0.2 boxscale) ))
	  	     	(command "PLINE" p1 "w" "0" "0" p4 p5 p1 p2 p3 "")
			(setq p2 (polar p2  (dtor 45) (* 0.1 boxscale) ))
			(if (= DIR 2)
			   (progn
				(command "LAYER" "SET" "TEXT" "")
				(setq str (strcat "INV:" (rtos INV 2 2)))
			   )
				(setq str (strcat "INV:" (rtos INV2 2 2)))
			)
			(command "TEXT" p2 (* 0.15 tboxscale) "0" str)
		   )
		)
	   );progn end
	   (progn
	       	(command "LAYER" "SET" "GUJO" "")			;draw BOX
 	      	(setq xx (cal "scale*(GND+B/2-Bsec/2)" ))
  	     	(setq yy (cal "scale*(-H)"))
   	    	(setq p1 (list xx yy))
		(setq p2 (polar p1  (dtor 0) (* Bsec scale) ))
		(setq p3 (polar p2  (dtor 90) (* Hcut scale) ))
		(setq p4 (polar p3  (dtor 180) (* Bsec scale) ))
  	     	(command "PLINE" p1 "w" "0" "0" p2 p3 p4 "c")
		(setq p1 p4)
		(setq p2 (polar p1  (dtor 0) (* Bsec scale) ))
		(setq p3 (polar p2  (dtor 90) (* Hsec scale) ))
		(setq p4 (polar p3  (dtor 180) (* Bsec scale) ))
  	     	(command "PLINE" p1 "w" "0" "0" p2 p3 p4 "c")
		(setq p1 (polar p1  (dtor 0) (* T3 scale) ))
		(setq p1 (polar p1  (dtor 90) (* T2 scale) ))
		(setq i 0)
		(while (< i type)
			(setq p2 (polar p1  (dtor 0) (* BR scale) ))
			(setq p3 (polar p2  (dtor 90) (* DIA scale) ))
			(setq p4 (polar p3  (dtor 180) (* BR scale) ))
  		     	(command "PLINE" p1 "w" "0" "0" p2 p3 p4 "c")
			(setq p1 (polar p1  (dtor 0) (* (+ T4 BR) scale) ))
			(setq i (+ i 1))
		);while
		(command "LAYER" "SET" "CHISU" "")
 	      	(setq p1 (polar p2  (dtor 180) (* (/ BR 2) scale) ))
 	      	(setq p2 (polar p1  (dtor 270) (* 1.0 scale) ))
		(setq p3 (polar p2  (dtor 0)  (* 1.2 scale) ))
		(setq p4 (polar p1  (dtor 240) (* 0.2 scale) ))
		(setq p5 (polar p1  (dtor 300) (* 0.2 scale) ))
  	     	(command "PLINE" p1 "w" "0" "0" p4 p5 p1 p2 p3 "")
		(command "LAYER" "SET" "TEXT" "")
		(setq p2 (polar p2  (dtor 45) (* 0.1 scale) ))
		(setq str (strcat "INV:" (rtos INV 2 2)))
		(command "TEXT" p2 (* 0.15 tscale) "0" str)
	   );progn end
	)

       	(command "LAYER" "SET" "CHISU" "")			;draw sand
       	(setq xx (cal "scale*(GND+SLOPE*(H-sand-COMP))" ))
       	(setq yy (cal "scale*(-H+sand)"))
       	(setq p1 (list xx yy))
	(setq angl 0)
	(if (> sand 0)
	(if (and (> sand Hcut) (< sand (+ Hcut DIA)))
		(progn
		(setq angl (h2angl DIA (- sand Hcut)))
		(setq val (cal "(DIA/2)*sin(angl/2)"))
	       	(setq xx (cal "scale*(GND+SLOPE*(H-COMP)+Bcut+DIA/2-val)" ))
 	      	(setq p2 (list xx yy))
	       	(command "LINE" p1 p2 "")
	       	(setq xx (cal "scale*(GND+SLOPE*(H-COMP)+Bcut+DIA/2+val)" ))
 	      	(setq p1 (list xx yy))
	       	(setq xx (cal "scale*(GND+SLOPE*(H-COMP)+Bcut*2+DIA+SLOPE*sand)" ))
 	      	(setq p2 (list xx yy))
	       	(command "LINE" p1 p2 "")
		)
		(progn
	       	(setq xx (cal "scale*(GND+SLOPE*(H-COMP)+Bcut*2+DIA+SLOPE*sand)" ))
 	      	(setq p2 (list xx yy))
	       	(command "LINE" p1 p2 "")
		)
	)
	)
   	(command "LAYER" "SET" "GUJO" "")					;draw concrete
	(if (> concB 0)
		(progn
		(if (> concB Bcut)
	     	  	(setq xx (cal "scale*(GND+SLOPE*(H-COMP))" ))
	     	  	(setq xx (cal "scale*(GND+SLOPE*(H-COMP)+Bcut-concB)" ))
			)
	       	(setq yy (cal "scale*(-H)"))
 	      	(setq p2 (list xx yy))
	       	(setq yy (cal "scale*(-H+concH)"))
 	      	(setq p1 (list xx yy))
	       	(command "LINE" p2 p1 "")
		);end progn
		(progn
	   	 	(setq xx (cal "scale*(GND+SLOPE*(H-COMP-concH))" ))
		   	(setq yy (cal "scale*(-H+concH)"))
 		    (setq p1 (list xx yy))
		);end progn
	)end if

	(if (and (> concH Hcut) (< concH (+ Hcut DIA)))
		;=========================================================================================
		(progn
			(setq val (cal "(DIA/2)*sin(concA/2)"))
	       	(setq xx (cal "scale*(GND+SLOPE*(H-COMP)+Bcut+DIA/2-val)" ))
 	     	(setq p2 (list xx yy))
  	    	(setq xx (cal "scale*(GND+SLOPE*(H-COMP)+Bcut+DIA/2+val)" ))
   		  	(setq p3 (list xx yy))
		    (command "LINE" p1 p2 "")

			(if(> concB 0)
				(progn
					(if (> concB Bcut)
				       	(setq xx (cal "scale*(GND+SLOPE*(H-COMP)+Bcut*2+DIA)" ))
				       	(setq xx (cal "scale*(GND+SLOPE*(H-COMP)+Bcut+DIA+concB)" ))
					)
				);end progn
				(progn
		  	     	(setq xx (cal "scale*(GND+SLOPE*(H-COMP)+Bcut*2+DIA+SLOPE*concH)" ))
				);end progn
			);end if
 		    (setq p4 (list xx yy))
	       	(command "LINE" p3 p4 "")
		);end progn
		;-----------------------------------------------------------------------------------------
		(progn
		(if(> concB 0)
			(if (> concB Bcut)
			       	(setq xx (cal "scale*(GND+SLOPE*(H-COMP)+Bcut*2+DIA)" ))
			       	(setq xx (cal "scale*(GND+SLOPE*(H-COMP)+Bcut+DIA+concB)" ))
				)
		       	(setq xx (cal "scale*(GND+SLOPE*(H-COMP)+Bcut*2+DIA+SLOPE*concH)" ))
			)
 	      	(setq p4 (list xx yy))
	       	(if (> concH 0) (command "LINE" p1 p4 "") )
		);end progn
		;=========================================================================================
	); end if

	(if (> concB 0)
		(progn
	       	(setq yy (cal "scale*(-H+concH)"))
 	      	(setq p1 (list xx yy))
	       	(setq yy (cal "scale*(-H)"))
 	      	(setq p2 (list xx yy))
	       	(command "LINE" p1 p2 "")
		)
	)

	(if (> manwork -1)
		(progn
	       	(command "LAYER" "SET" "CHISU" "")			;draw manwork
		(command "LINETYPE" "S" "HIDDEN" "")
	       	(setq xx (cal "scale*(GND+SLOPE*(H-COMP-Hcut-DIA-manwork))" ))
 	      	(setq yy (cal "scale*(-H+Hcut+DIA+manwork)"))
  	     	(setq p1 (list xx yy))
   	    	(setq xx (cal "scale*(GND+SLOPE*(H-COMP)+Bcut*2+DIA+SLOPE*(Hcut+DIA+manwork))" ))
    	  	(setq p2 (list xx yy))
     	  	(command "LINE" p1 p2 "")
		(command "LINETYPE" "S" "BYLAYER" "")
		)
	)


;humanity (보도)를 그린다.
(drawHumanity "drawHumanity"	)
	


(if (> concrete 0)
   (progn
      (princ "step1")
	   ; concrete >0  , asphalt1 > 0 이면 asphalt1을 그리고 concrete를 그린다. 

		(if (> asphalt1 0)
			(progn
			  (princ "step2")
						; Asphalt를 그린다.
						(drawAsphalt "drawAsphalt")	
						 ;Concrete를 그린다.
						(drawConcrete "drawConcrete")				
			)
		)
		; concrete > 0  asphalt1 = 0 이면 concrete를 그리고 asphalt1을 그린다.
		(if (= asphalt1 0)
			(progn
			  (princ "step3")
						 ;Concrete를 그린다.
						(drawConcrete "drawConcrete")				
		
						; Asphalt를 그린다.
						(drawAsphalt "drawAsphalt")	
			)
		)
	)
)

(if (= concrete 0)
	(progn
	  (princ "step4")
		 ;Concrete를 그린다.
		(drawConcrete "drawConcrete")				

		; Asphalt를 그린다.
		(drawAsphalt "drawAsphalt")	
	)
)


;Complay (보조기층)를 그린다.
(drawComplay "drawComplay")

;mixlay (혼합기층)를 그린다.
(drawMixlay "drawComplay")
	;----------------------------------------------------------------- draw soil table
	(if (/= DIR 0)
	       	(setq xx (cal "scale*(3.5*GND+B+B2)" ))
	       	(setq xx (cal "scale*(2.5*GND+B)" ))
	)
	(setq yy (cal "-scale*1"))
      	(setq p1 (list xx yy))
	(setq p2 (polar p1  (dtor 0 ) (cal "boxscale*4.8")))
	(setq p3 (polar p2  (dtor 270 ) (cal "boxscale*2.8")))
	(setq p4 (polar p3  (dtor 180 ) (cal "boxscale*4.8")))
       	(command "LAYER" "SET" "STEEL" "")
       	(command "PLINE" p1 "w" "0" "0" p2 p3 p4 "c")

	(if (> sangsu 0)
	   (progn
		(setq p2 (polar p1  (dtor 270 ) (cal "boxscale*0.4")))	;STATION ONLY
		(setq p3 (polar p2  (dtor 0 ) (cal "boxscale*4.8")))
		(setq p4 (polar p2  (dtor 45 ) (cal "-boxscale*0.1")))
 	      	(command "LAYER" "SET" "PIPE" "")
		(setq str (strcat "   STA. " nochain))
		(command "TEXT" p4 (* 0.2 boxscale) "0" str)

		(setq p2 (polar p2  (dtor 270 ) (cal "boxscale*0.3")))	
		(setq p3 (polar p2  (dtor 0 ) (cal "boxscale*4.8")))
 	      	(command "LAYER" "SET" "STEEL" "")
		(setq p4 (polar p2  (dtor  90 ) (cal "boxscale*0.1")))	
		(setq p5 (polar p3  (dtor  90 ) (cal "boxscale*0.1")))
 	  	(command "LINE" p4 p5 "")
	   )
	   (progn
		(setq p2 (polar p1  (dtor 270 ) (cal "boxscale*0.4")))	;LINENAME
		(setq p3 (polar p2  (dtor 0 ) (cal "boxscale*4.8")))
		(setq p4 (polar p2  (dtor 45 ) (cal "boxscale*0.1")))
 	      	(command "LAYER" "SET" "PIPE" "")
		(command "TEXT" p4 (* 0.2 boxscale) "0" LINENAME)
 	  	(command "LINE" p2 p3 "")

		(setq p2 (polar p2  (dtor 270 ) (cal "boxscale*0.3")))	;Station
		(setq p3 (polar p2  (dtor 0 ) (cal "boxscale*4.8")))
		(setq p4 (polar p2  (dtor 45 ) (cal "boxscale*0.05")))
 	      	(command "LAYER" "SET" "TEXT" "")
		(setq str (strcat "   STA. " nochain))
		(command "TEXT" p4 (* 0.15 tboxscale) "0" str)
	   )
	)

       	(command "LAYER" "SET" "CHISU" "")			;Vertical line
   	(command "LINE" p2 p3 "")
	(setq p5 (polar p2  (dtor 0 ) (cal "boxscale*1.2")))
	(setq p6 (polar p5  (dtor 270 ) (cal "boxscale*2.1")))
   	(command "LINE" p5 p6 "")
	(setq p5 (polar p2  (dtor 0 ) (cal "boxscale*2.4")))
	(setq p6 (polar p5  (dtor 270 ) (cal "boxscale*2.1")))
   	(command "LINE" p5 p6 "")
	(setq p5 (polar p2  (dtor 0 ) (cal "boxscale*3.6")))
	(setq p6 (polar p5  (dtor 270 ) (cal "boxscale*2.1")))
   	(command "LINE" p5 p6 "")

	(setq p2 (polar p2  (dtor 270 ) (cal "boxscale*0.3")))	;Ground Height
	(setq p3 (polar p2  (dtor 0 ) (cal "boxscale*2.4")))
	(setq p4 (polar p2  (dtor 45 ) (cal "boxscale*0.05")))
       	(command "LAYER" "SET" "TEXT" "")
	(command "TEXT" p4 (* 0.15 tboxscale) "0" " 지 반 고")
	(setq p4 (polar p3  (dtor 135 ) (cal "boxscale*0.05")))
	(setq p4 (polar p4  (dtor 180 ) (cal "boxscale*0.2")))
	(setq str (rtos GH 2 2))
	(command "TEXT" "j" "Right" p4 (* 0.15 tboxscale) "0" str)
       	(command "LAYER" "SET" "CHISU" "")
   	(command "LINE" p2 p3 "")

	(setq p2 (polar p2  (dtor 270 ) (cal "boxscale*0.3")))	;Cover Elevation
	(setq p3 (polar p2  (dtor 0 ) (cal "boxscale*2.4")))
	(setq p4 (polar p2  (dtor 45 ) (cal "boxscale*0.05")))
       	(command "LAYER" "SET" "TEXT" "")
	(command "TEXT" p4 (* 0.15 tboxscale) "0" " 토  피")
	(setq p4 (polar p3  (dtor 135 ) (cal "boxscale*0.05")))
	(setq p4 (polar p4  (dtor 180 ) (cal "boxscale*0.2")))
	(setq str (rtos (cal "GH-INV-DIA") 2 2))
	(command "TEXT" "j" "Right" p4 (* 0.15 tboxscale) "0" str)
       	(command "LAYER" "SET" "CHISU" "")
   	(command "LINE" p2 p3 "")

	(setq p2 (polar p2  (dtor 270 ) (cal "boxscale*0.3")))	;Cutting Area
	(setq p3 (polar p2  (dtor 0 ) (cal "boxscale*2.4")))
	(setq p4 (polar p2  (dtor 45 ) (cal "boxscale*0.05")))
       	(command "LAYER" "SET" "TEXT" "")
	(command "TEXT" p4 (* 0.15 tboxscale) "0" " 터 파 기")
	(setq p4 (polar p3  (dtor 135 ) (cal "boxscale*0.05")))
	(setq p4 (polar p4  (dtor 180 ) (cal "boxscale*0.2")))
	(setq str (rtos area1 2 2))
	(command "TEXT" "j" "Right" p4 (* 0.15 tboxscale) "0" str)
       	(command "LAYER" "SET" "CHISU" "")
   	(command "LINE" p2 p3 "")

	(setq p2 (polar p2  (dtor 270 ) (cal "boxscale*0.3")))	;fill manwork
	(setq p5 (polar p2  (dtor 0 ) (cal "boxscale*0.5")))
	(setq p3 (polar p2  (dtor 0 ) (cal "boxscale*2.4")))
	(setq p4 (polar p2  (dtor 45 ) (cal "boxscale*0.05")))
	(setq p6 (polar p5  (dtor 45 ) (cal "boxscale*0.05")))
	(setq p7 (polar p5  (dtor 90 ) (cal "boxscale*0.3")))
	(setq p8 (polar p5  (dtor 270 ) (cal "boxscale*0.3")))
       	(command "LAYER" "SET" "TEXT" "")
	(command "TEXT" p4 (* 0.15 tboxscale) "0" "되메")
	(command "TEXT" p6 (* 0.15 tboxscale) "0" "관주위")
	(setq p4 (polar p3  (dtor 135 ) (cal "boxscale*0.05")))
	(setq p4 (polar p4  (dtor 180 ) (cal "boxscale*0.2")))
	(setq str (rtos area2 2 2))
	(command "TEXT" "j" "Right" p4 (* 0.15 tboxscale) "0" str)
       	(command "LAYER" "SET" "CHISU" "")
   	(command "LINE" p5 p3 "")
   	(command "LINE" p7 p8 "")

	(setq p2 (polar p2  (dtor 270 ) (cal "boxscale*0.3")))	;fill machine
	(setq p5 (polar p2  (dtor 0 ) (cal "boxscale*0.5")))
	(setq p3 (polar p2  (dtor 0 ) (cal "boxscale*2.4")))
	(setq p4 (polar p2  (dtor 45 ) (cal "boxscale*0.05")))
	(setq p4 (polar p4  (dtor 90 ) (cal "boxscale*0.05")))
	(setq p6 (polar p5  (dtor 45 ) (cal "boxscale*0.05")))
       	(command "LAYER" "SET" "TEXT" "")
	(command "TEXT" p4 (* 0.15 tboxscale) "0" "우기")
	(command "TEXT" p6 (* 0.15 tboxscale) "0" "관상단")
	(setq p4 (polar p3  (dtor 135 ) (cal "boxscale*0.05")))
	(setq p4 (polar p4  (dtor 180 ) (cal "boxscale*0.2")))
	(setq str (rtos area3 2 2))
	(command "TEXT" "j" "Right" p4 (* 0.15 tboxscale) "0" str)
       	(command "LAYER" "SET" "CHISU" "")
   	(command "LINE" p2 p3 "")

	(setq p2 (polar p2  (dtor 270 ) (cal "boxscale*0.3")))
	(setq p3 (polar p2  (dtor 0 ) (cal "boxscale*2.4")))
	(setq p4 (polar p2  (dtor 45 ) (cal "boxscale*0.05")))
       	(command "LAYER" "SET" "TEXT" "")
	(command "TEXT" p4 (* 0.15 tboxscale) "0" " 잔토처리")
	(setq p4 (polar p3  (dtor 135 ) (cal "boxscale*0.05")))
	(setq p4 (polar p4  (dtor 180 ) (cal "boxscale*0.2")))
	(setq str (rtos area4 2 2))
	(command "TEXT" "j" "Right" p4 (* 0.15 tboxscale) "0" str)
       	(command "LAYER" "SET" "CHISU" "")
   	(command "LINE" p2 p3 "")

	(setq p2 (polar p2  (dtor 270 ) (cal "boxscale*0.3")))
	(setq p3 (polar p2  (dtor 0 ) (cal "boxscale*2.4")))
	(setq p4 (polar p2  (dtor 45 ) (cal "boxscale*0.05")))
       	(command "LAYER" "SET" "TEXT" "")
	(command "TEXT" p4 (* 0.15 tboxscale) "0" " 모래부설")
	(setq p4 (polar p3  (dtor 135 ) (cal "boxscale*0.05")))
	(setq p4 (polar p4  (dtor 180 ) (cal "boxscale*0.2")))
	(setq str (rtos area5 2 2))
	(command "TEXT" "j" "Right" p4 (* 0.15 tboxscale) "0" str)

	(setq p2 (polar p1  (dtor 270 ) (cal "boxscale*1.0")))	;Invert Elevation
	(setq p2 (polar p2  (dtor 0 ) (cal "boxscale*2.4")))
	(setq p3 (polar p2  (dtor 0 ) (cal "boxscale*2.4")))
	(setq p4 (polar p2  (dtor 45 ) (cal "boxscale*0.05")))
       	(command "LAYER" "SET" "TEXT" "")
	(command "TEXT" p4 (* 0.15 tboxscale) "0" " 관 저 고")
	(setq p4 (polar p3  (dtor 135 ) (cal "boxscale*0.05")))
	(setq p4 (polar p4  (dtor 180 ) (cal "boxscale*0.2")))
	(setq str (rtos INV 2 2))
	(command "TEXT" "j" "Right" p4 (* 0.15 tboxscale) "0" str)
       	(command "LAYER" "SET" "CHISU" "")
   	(command "LINE" p2 p3 "")

	(setq p2 (polar p2  (dtor 270 ) (cal "boxscale*0.3")))
	(setq p5 (polar p2  (dtor 0 ) (cal "boxscale*0.7")))
	(setq p3 (polar p2  (dtor 0 ) (cal "boxscale*2.4")))
	(setq p4 (polar p2  (dtor 45 ) (cal "boxscale*0.05")))
	(setq p6 (polar p5  (dtor 45 ) (cal "boxscale*0.05")))
	(setq p7 (polar p5  (dtor 90 ) (cal "boxscale*0.3")))
	(setq p8 (polar p5  (dtor 270 ) (cal "boxscale*0.3")))
       	(command "LAYER" "SET" "TEXT" "")
       	
	(setq wow1 0)   ; 밑에서 분기 처리 해불라고 
       	
	(if (> concrete 0)
	   (progn
	   	(if (= concrete 0.07)
	   		(progn
	   			(if (= complay 0.15)
	   				(if ( = sand 0.05)
	   				   (progn
	   						(command "TEXT" p4 (* 0.15 tboxscale) "0" "투수콘")
	   						(setq wow1 2)
	   					)
	   				)
	   			)
	   		)
	   	   (progn 
	   	   	(if (> asphalt1 0)	   	   		
	   	   		(command "TEXT" p4 (* 0.15 tboxscale) "0" "A+C")	;110 이 아니면	
	   	   		(command "TEXT" p4 (* 0.15 tboxscale) "0" "CONC.")	; 걍 콩크리트	   	   		
	   	   	)	   	  
	   	   ) 
	   	)	   
	   )
	   (progn ; concrete 가 0보다 <= 
	   	(if (> asphalt1 0)
	   		(progn
	   				(if  (= asphalt1 0.11)
	   					(progn
	   						(if (= asphalt2 0.1)
	   						  (progn
		   							(command "TEXT" p4 (* 0.15 tboxscale) "0" "ASP")  ; ASP(국도)
		   							(setq wow1 1)
	   							)
	   						)
	   					)	   					
	   				)
	   		)	   		
	   	)			
		)
	)
	(if (> humanity 0)
		(command "TEXT" p4 (* 0.15 tboxscale) "0" "보 도")
	)
	(if (> asphalt1 0)
	   (progn
	   	(if (= concrete 0)
				(command "TEXT" p4 (* 0.15 tboxscale) "0" "ASP.")
			)
		)
	)
	(command "TEXT" p6 (* 0.15 tboxscale) "0" "파취")
	(setq p4 (polar p3  (dtor 135 ) (cal "boxscale*0.05")))
	(setq p4 (polar p4  (dtor 180 ) (cal "boxscale*0.2")))
	(command "TEXT" "j" "Right" p4 (* 0.15 tboxscale) "0" (rtos area6 2 2))
       	(command "LAYER" "SET" "CHISU" "")
   	(command "LINE" p5 p3 "")
   	(command "LINE" p7 p8 "")

	(setq p2 (polar p2  (dtor 270 ) (cal "boxscale*0.3")))
	(setq p5 (polar p2  (dtor 0 ) (cal "boxscale*0.7")))
	(setq p3 (polar p2  (dtor 0 ) (cal "boxscale*2.4")))
	(setq p4 (polar p2  (dtor 45 ) (cal "boxscale*0.05")))
	(setq p4 (polar p4  (dtor 90 ) (cal "boxscale*0.05")))
	(setq p6 (polar p5  (dtor 45 ) (cal "boxscale*0.05")))
       	(command "LAYER" "SET" "TEXT" "")
   ( if ( = wow1 1)
   	(command "TEXT" p4 (* 0.15 tboxscale) "0" "(국도)")   	
   )  

   ( if ( = wow1 2)
   	(command "TEXT" p4 (* 0.15 tboxscale) "0" "")   	
   )  

   
   ( if ( = wow1 0)
   	(command "TEXT" p4 (* 0.15 tboxscale) "0" "포 장")
   )
   
        	
	;(command "TEXT" p4 (* 0.15 tboxscale) "0" "포 장")
	(command "TEXT" p6 (* 0.15 tboxscale) "0" "복구")
	(setq p4 (polar p3  (dtor 135 ) (cal "boxscale*0.05")))
	(setq p4 (polar p4  (dtor 180 ) (cal "boxscale*0.2")))
	(command "TEXT" "j" "Right" p4 (* 0.15 tboxscale) "0" (rtos area7 2 2))
       	(command "LAYER" "SET" "CHISU" "")
   	(command "LINE" p2 p3 "")

	(setq p2 (polar p2  (dtor 270 ) (cal "boxscale*0.3")))
	(setq p3 (polar p2  (dtor 0 ) (cal "boxscale*2.4")))
	(setq p4 (polar p2  (dtor 45 ) (cal "boxscale*0.05")))
       	(command "LAYER" "SET" "TEXT" "")
	(command "TEXT" p4 (* 0.15 tboxscale) "0" " 보조기층")
	(setq p4 (polar p3  (dtor 135 ) (cal "boxscale*0.05")))
	(setq p4 (polar p4  (dtor 180 ) (cal "boxscale*0.2")))
	(setq str (rtos area8 2 2))
	(command "TEXT" "j" "Right" p4 (* 0.15 tboxscale) "0" str)
       	(command "LAYER" "SET" "CHISU" "")
   	(command "LINE" p2 p3 "")

	(setq p2 (polar p2  (dtor 270 ) (cal "boxscale*0.3")))
	(setq p3 (polar p2  (dtor 0 ) (cal "boxscale*2.4")))
	(setq p4 (polar p2  (dtor 45 ) (cal "boxscale*0.05")))
	(if(> area9 0)
	  (progn
       		(command "LAYER" "SET" "TEXT" "")
		(command "TEXT" p4 (* 0.15 tboxscale) "0" " 혼합기층")
		(setq p4 (polar p3  (dtor 135 ) (cal "boxscale*0.05")))
		(setq p4 (polar p4  (dtor 180 ) (cal "boxscale*0.2")))
		(setq str (rtos area9 2 2))
		(command "TEXT" "j" "Right" p4 (* 0.15 tboxscale) "0" str)
	  )
	)
       	(command "LAYER" "SET" "CHISU" "")
   	(command "LINE" p2 p3 "")

	(setq p2 (polar p2  (dtor 270 ) (cal "boxscale*0.3")))
	(setq p3 (polar p2  (dtor 0 ) (cal "boxscale*2.4")))
	(setq p4 (polar p2  (dtor 45 ) (cal "boxscale*0.05")))
	(if(> area10 0)
	  (progn
	       	(command "LAYER" "SET" "TEXT" "")
		(command "TEXT" p4 (* 0.15 tboxscale) "0" " 거 푸 집")
		(setq p4 (polar p3  (dtor 135 ) (cal "boxscale*0.05")))
		(setq p4 (polar p4  (dtor 180 ) (cal "boxscale*0.2")))
		(command "TEXT" "j" "Right" p4 (* 0.15 tboxscale) "0" (rtos area10 2 2))
	  )
	)
       	(command "LAYER" "SET" "CHISU" "")
   	(command "LINE" p2 p3 "")

	(setq p2 (polar p2  (dtor 270 ) (cal "boxscale*0.3")))
	(setq p3 (polar p2  (dtor 0 ) (cal "boxscale*2.4")))
	(setq p4 (polar p2  (dtor 45 ) (cal "boxscale*0.05")))
	(if(> area11 0)
	  (progn
	       	(command "LAYER" "SET" "TEXT" "")
		(command "TEXT" p4 (* 0.15 tboxscale) "0" " 콘크리트")
		(setq p4 (polar p3  (dtor 135 ) (cal "boxscale*0.05")))
		(setq p4 (polar p4  (dtor 180 ) (cal "boxscale*0.2")))
		(setq str (rtos area11 2 2))
		(command "TEXT" "j" "Right" p4 (* 0.15 tboxscale) "0" str)
	  )
	)

;;-------------------------------------------------------
;;  MOVE ALL
;;-------------------------------------------------------
(if (> RIGHT 0)
    (progn	
	(if (> Ncol 4)
		(progn
	     	(setq p1 (list 0 0))
		(setq Nrow (+ Nrow 1))
		(if (> Nrow 3)
			(progn
			(setq p1 (polar p1  (dtor 0 ) (cal "boxscale*14*4")))
			(setq p1 (polar p1  (dtor 90 ) (cal "boxscale*12*3")))
			(setq Nrow 0)
			)
			(progn
			(setq p1 (polar p1  (dtor 180 ) (cal "boxscale*14*4")))
			(setq p1 (polar p1  (dtor 270 ) (cal "boxscale*12")))
			)
			)
	     	(command "UCS" "O" p1)
		(setq Ncol 0)
		)
		(progn
 	     	(setq p1 (list 0 0))
		(setq p1 (polar p1  (dtor 0 ) (cal "boxscale*14")))
  	     	(command "UCS" "O" p1)
		)
	)
    )
    (progn	
	(if (> Nrow 3)
		(progn
	     	(setq p1 (list 0 0))
		(setq Ncol (+ Ncol 1))
		(if (> Ncol 4)
			(progn
			(setq p1 (polar p1  (dtor 270 ) (cal "boxscale*12*3")))
			(setq p1 (polar p1  (dtor 0 ) (cal "boxscale*14*4")))
			(setq Ncol 0)
			)
			(progn
			(setq p1 (polar p1  (dtor 270 ) (cal "boxscale*12*3")))
			(setq p1 (polar p1  (dtor 0 ) (cal "boxscale*14")))
			)
			)
	     	(command "UCS" "O" p1)
		(setq Nrow 0)
		)
		(progn
 	     	(setq p1 (list 0 0))
		(setq p1 (polar p1  (dtor 90 ) (cal "boxscale*12")))
  	     	(command "UCS" "O" p1)
		)
	)
    )
)

;;-------------------------------------------------------
;;  END OF WHILE
;;-------------------------------------------------------
   );;while


;;-------------------------------------------------------
;;  file close
;;-------------------------------------------------------

   (setq infile (close infile))
   (setvar "BLIPMODE" 0)
   (prompt "\n*** Program Success !! ***")
);defun...

(defun existarx(arxname / FIND)
	(setq i 0) 
	(setq FIND -1)
	(setq NOWARX (arx))
	(while (< i (- (length NOWARX) 1))
		(progn
		(if (= arxname (nth i NOWARX)) (setq FIND (+ i 1)) )
		(setq i (+ i 1))
		)
	)
	(setq FIND FIND)
)
(defun angl2h(DIA angle / hh)
	(setq hh (cal "(DIA/2)*(1-cos(angle/2))"))
	(setq hh hh)
)
(defun h2angl(DIA hh / angle)
	(setq angle (cal "2*acos(1-2*hh/DIA)"))
	(setq angle angle)
)
(defun dtor(deg / rad)
	(setq rad (cal "d2r(deg)"))
	(setq rad rad)
)

(defun drawConcrete (msg)
	(princ msg)
       	(command "LAYER" "SET" "CHISU" "")
	(if (> concrete 0)
		(progn
		(if (/= DIR 0)
		       	(setq xx (cal "scale*(2*GND+B+B2)" ))
		       	(setq xx (cal "scale*(2*GND+B)" ))
		)
	      	(setq yy (cal "yy-scale*concrete"))
  	     	(setq p1 (list 0.0 yy))
   	    	(setq p2 (list xx  yy))
   	   	(command "LINE" p1 p2 "")
		(setq p3 (polar p1  (dtor 90) (cal "scale*concrete") ))
		(setq p4 (polar p3  (dtor 0)  (cal "scale*GND") ))
		(setq p5 (polar p4  (dtor 270)  (cal "scale*concrete") ))
		(command "hatch" "AR-CONC" (* 0.03 scale) "90" "" "N" p3 p4 p5 p1 "c" "")
		(setq p3 (polar p2  (dtor 90) (cal "scale*concrete") ))
		(setq p4 (polar p3  (dtor 180)  (cal "scale*GND") ))
		(setq p5 (polar p4  (dtor 270)  (cal "scale*concrete") ))
		(command "hatch" "AR-CONC" (* 0.03 scale) "90" "" "N" p3 p4 p5 p2 "c" "")
		(setq p3 (polar p1  (dtor 0) (cal "scale*GND/2") ))
		(setq p3 (polar p3  (dtor 90) (cal "scale*concrete/2") ))
		(command "donut" 0 (* 0.08 boxscale) p3 "")
		(setq p4 (list (cal "scale*GND/2") yylay))
		(setq p5 (polar p4  (dtor 0 ) (cal "boxscale*GND")))
	       	(command "PLINE" p3 "w" "0" "0" p4 p5 "")
	       	(command "LAYER" "SET" "TEXT" "")
		(setq str (strcat " 콘크리트(25-210-8) T=" (rtos (* concrete 1000) 2 0)))
		(command "TEXT" "J" "ML" p5 (* 0.15 tboxscale) "0" str)
		(setq yylay (cal "yylay-boxscale*0.3"))
		)
	)
)
(defun drawComplay (msg)
 
(princ msg)
       	(command "LAYER" "SET" "CHISU" "")
	(if (> complay 0)
		(progn
		(if (/= DIR 0)
		       	(setq xx (cal "scale*(2*GND+B+B2)" ))
		       	(setq xx (cal "scale*(2*GND+B)" ))
		)
	      	(setq yy (cal "yy-scale*complay"))
  	     	(setq p1 (list 0.0 yy))
   	    	(setq p2 (list xx  yy))
   	   	(command "LINE" p1 p2 "")
	      	(setq yy (cal "yy+scale*complay"))
  	     	(setq p3 (list 0.0 yy))
  	     	(setq p4 (list (cal "scale*GND" ) yy))
	      	(setq yy (cal "yy-scale*complay"))
  	     	(setq p5 (list (cal "scale*(GND+complay*SLOPE)" ) yy))
		(command "hatch" "AR-HBONE" (* 0.04 scale) "90" "" "N" p3 p4 p5 p1 "c" "")
	      	(setq yy (cal "yy+scale*complay"))
  	     	(setq p3 (list xx yy))
  	     	(setq p4 (list (cal "xx-scale*GND" ) yy))
	      	(setq yy (cal "yy-scale*complay"))
  	     	(setq p5 (list (cal "xx-scale*(GND+complay*SLOPE)" ) yy))
		(command "hatch" "AR-HBONE" (* 0.04 scale) "90" "" "N" p3 p4 p5 p2 "c" "")
		(setq p3 (polar p1  (dtor 0) (cal "scale*GND/2") ))
		(setq p3 (polar p3  (dtor 90) (cal "scale*complay/2") ))
		(command "donut" 0 (* 0.08 boxscale) p3 "")
		(setq p4 (list (cal "scale*GND/2") yylay))
		(setq p5 (polar p4  (dtor 0 ) (cal "boxscale*GND")))
	       	(command "PLINE" p3 "w" "0" "0" p4 p5 "")
	       	(command "LAYER" "SET" "TEXT" "")
		(setq str (strcat " 보조기층 T=" (rtos (* complay 1000) 2 0)))
		(command "TEXT" "J" "ML" p5 (* 0.15 tboxscale) "0" str)
		(setq yylay (cal "yylay-boxscale*0.3"))
		)
	)
)


(defun drawSand(msg)
 
(princ msg)
       	(command "LAYER" "SET" "CHISU" "")
	(if (> complay 0)
		(progn
		(if (/= DIR 0)
		       	(setq xx (cal "scale*(2*GND+B+B2)" ))
		       	(setq xx (cal "scale*(2*GND+B)" ))
		)
	      	(setq yy (cal "yy-scale*complay"))
  	     	(setq p1 (list 0.0 yy))
   	    	(setq p2 (list xx  yy))
   	   	(command "LINE" p1 p2 "")
	      	(setq yy (cal "yy+scale*complay"))
  	     	(setq p3 (list 0.0 yy))
  	     	(setq p4 (list (cal "scale*GND" ) yy))
	      	(setq yy (cal "yy-scale*complay"))
  	     	(setq p5 (list (cal "scale*(GND+complay*SLOPE)" ) yy))
		(command "hatch" "AR-HBONE" (* 0.04 scale) "90" "" "N" p3 p4 p5 p1 "c" "")
	      	(setq yy (cal "yy+scale*complay"))
  	     	(setq p3 (list xx yy))
  	     	(setq p4 (list (cal "xx-scale*GND" ) yy))
	      	(setq yy (cal "yy-scale*complay"))
  	     	(setq p5 (list (cal "xx-scale*(GND+complay*SLOPE)" ) yy))
		(command "hatch" "AR-HBONE" (* 0.04 scale) "90" "" "N" p3 p4 p5 p2 "c" "")
		(setq p3 (polar p1  (dtor 0) (cal "scale*GND/2") ))
		(setq p3 (polar p3  (dtor 90) (cal "scale*complay/2") ))
		(command "donut" 0 (* 0.08 boxscale) p3 "")
		(setq p4 (list (cal "scale*GND/2") yylay))
		(setq p5 (polar p4  (dtor 0 ) (cal "boxscale*GND")))
	       	(command "PLINE" p3 "w" "0" "0" p4 p5 "")
	       	(command "LAYER" "SET" "TEXT" "")
		(setq str (strcat " 모래 T=" (rtos (* complay 1000) 2 0)))
		(command "TEXT" "J" "ML" p5 (* 0.15 tboxscale) "0" str)
		(setq yylay (cal "yylay-boxscale*0.3"))
		)
	)
)


(defun drawMixlay (msg)

(princ msg)

       	(command "LAYER" "SET" "CHISU" "")
	(if (> mixlay 0)
		(progn
		(if (/= DIR 0)
		       	(setq xx (cal "scale*(2*GND+B+B2)" ))
		       	(setq xx (cal "scale*(2*GND+B)" ))
		)
	      	(setq yy (cal "yy-scale*mixlay"))
  	     	(setq p1 (list 0.0 yy))
   	    	(setq p2 (list xx  yy))
   	   	(command "LINE" p1 p2 "")
	      	(setq yy (cal "yy+scale*mixlay"))
  	     	(setq p3 (list 0.0 yy))
  	     	(setq p4 (list (cal "scale*(GND+complay*SLOPE)" ) yy))
	      	(setq yy (cal "yy-scale*mixlay"))
  	     	(setq p5 (list (cal "scale*(GND+(complay+mixlay)*SLOPE)" ) yy))
		(command "hatch" "AR-PARQ1" (* 0.04 scale) "45" "" "N" p3 p4 p5 p1 "c" "")
	      	(setq yy (cal "yy+scale*mixlay"))
  	     	(setq p3 (list xx yy))
  	     	(setq p4 (list (cal "xx-scale*(GND+complay*SLOPE)" ) yy))
	      	(setq yy (cal "yy-scale*mixlay"))
  	     	(setq p5 (list (cal "xx-scale*(GND+(complay+mixlay)*SLOPE)" ) yy))
		(command "hatch" "AR-PARQ1" (* 0.04 scale) "45" "" "N" p3 p4 p5 p2 "c" "")
		(setq p3 (polar p1  (dtor 0) (cal "scale*GND/2") ))
		(setq p3 (polar p3  (dtor 90) (cal "scale*mixlay/2") ))
		(command "donut" 0 (* 0.08 boxscale) p3 "")
		(setq p4 (list (cal "scale*GND/2") yylay))
		(setq p5 (polar p4  (dtor 0 ) (cal "boxscale*GND")))
	       	(command "PLINE" p3 "w" "0" "0" p4 p5 "")
	       	(command "LAYER" "SET" "TEXT" "")
		(setq str (strcat " 혼합기층 T=" (rtos (* mixlay 1000) 2 0)))
		(command "TEXT" "J" "ML" p5 (* 0.15 tboxscale) "0" str)
		)
	)
)

(defun drawHumanity (msg)

(princ msg)

       	(command "LAYER" "SET" "CHISU" "");---------------------------------------------------------draw road section
	(setq yy 0)
	(setq yylay (cal "boxscale*5*GND"))
  	(if (> humanity 0)
		(progn
		(if (/= DIR 0)
		       	(setq xx (cal "scale*(2*GND+B+B2)" ))
		       	(setq xx (cal "scale*(2*GND+B)" ))
		)
	      	(setq yy (cal "-scale*humanity"))
  	     	(setq p1 (list 0   yy))
   	    	(setq p2 (list xx  yy))
   	   	(command "LINE" p1 p2 "")
		(setq p3 (polar p1  (dtor 90) (cal "scale*humanity") ))
		(setq p4 (polar p3  (dtor 0)  (cal "scale*GND") ))
		(setq p5 (polar p4  (dtor 270)  (cal "scale*humanity") ))
		(command "hatch" "PLAST" (* 0.5 scale) "90" "" "N" p3 p4 p5 p1 "c" "")
		(setq p3 (polar p2  (dtor 90) (cal "scale*humanity") ))
		(setq p4 (polar p3  (dtor 180)  (cal "scale*GND") ))
		(setq p5 (polar p4  (dtor 270)  (cal "scale*humanity") ))
		(command "hatch" "PLAST" (* 0.5 scale) "90" "" "N" p3 p4 p5 p2 "c" "")
		(setq p3 (polar p1  (dtor 0) (cal "scale*GND/2") ))
		(setq p3 (polar p3  (dtor 90) (cal "scale*humanity/2") ))
		(command "donut" 0 (* 0.08 boxscale) p3 "")
		(setq p4 (list (cal "scale*GND/2") yylay))
		(setq p5 (polar p4  (dtor 0 ) (cal "boxscale*GND")))
	       	(command "PLINE" p3 "w" "0" "0" p4 p5 "")
	       	(command "LAYER" "SET" "TEXT" "")
		(setq str (strcat " 보도블럭 T=" (rtos (* humanity 1000) 2 0)))
		(command "TEXT" "J" "ML" p5 (* 0.15 tboxscale) "0" str)
		(setq yylay (cal "yylay-boxscale*0.3"))
		)
	)

)

(defun drawAsphalt (msg)

	(princ msg)

       	(command "LAYER" "SET" "CHISU" "")
	(if (> asphalt1 0)
		(progn
		(if (/= DIR 0)
		       	(setq xx (cal "scale*(2*GND+B+B2)" ))
		       	(setq xx (cal "scale*(2*GND+B)" ))
		)
	      	(setq yy (cal "yy-scale*asphalt1"))
  	     	(setq p1 (list 0.0 yy))
   	    	(setq p2 (list xx  yy))
   	   	(command "LINE" p1 p2 "")
		(setq p3 (polar p1  (dtor 90) (cal "scale*asphalt1") ))
		(setq p4 (polar p3  (dtor 0)  (cal "scale*GND") ))
		(setq p5 (polar p4  (dtor 270)  (cal "scale*asphalt1") ))
		(command "hatch" "ANSI31" (* 0.2 scale) "90" "" "N" p3 p4 p5 p1 "c" "")
		(setq p3 (polar p2  (dtor 90) (cal "scale*asphalt1") ))
		(setq p4 (polar p3  (dtor 180)  (cal "scale*GND") ))
		(setq p5 (polar p4  (dtor 270)  (cal "scale*asphalt1") ))
		(command "hatch" "ANSI31" (* 0.2 scale) "90" "" "N" p3 p4 p5 p2 "c" "")
		(setq p3 (polar p1  (dtor 0) (cal "scale*GND/2") ))
		(setq p3 (polar p3  (dtor 90) (cal "scale*asphalt1/2") ))
		(command "donut" 0 (* 0.08 boxscale) p3 "")
		(setq p4 (list (cal "scale*GND/2") yylay))
		(setq p5 (polar p4  (dtor 0 ) (cal "boxscale*GND")))
	       	(command "PLINE" p3 "w" "0" "0" p4 p5 "")
	       	(command "LAYER" "SET" "TEXT" "")
		(setq str (strcat " 표층 (아스콘#78) T=" (rtos (* asphalt1 1000) 2 0)))
		(command "TEXT" "J" "ML" p5 (* 0.15 tboxscale) "0" str)
	       	(command "LAYER" "SET" "CHISU" "")
		(setq yylay (cal "yylay-boxscale*0.3"))

		(if (/= DIR 0)
		       	(setq xx (cal "scale*(2*GND+B+B2)" ))
		       	(setq xx (cal "scale*(2*GND+B)" ))
		)
	      	(setq yy (cal "yy-scale*asphalt2"))
  	     	(setq p1 (list 0.0 yy))
   	    	(setq p2 (list xx  yy))
   	   	(command "LINE" p1 p2 "")
		(setq p3 (polar p1  (dtor 90) (cal "scale*asphalt2") ))
		(setq p4 (polar p3  (dtor 0)  (cal "scale*GND") ))
		(setq p5 (polar p4  (dtor 270)  (cal "scale*asphalt2") ))
		(command "hatch" "ANSI38" (* 0.4 scale) "90" "" "N" p3 p4 p5 p1 "c" "")
		(setq p3 (polar p2  (dtor 90) (cal "scale*asphalt2") ))
		(setq p4 (polar p3  (dtor 180)  (cal "scale*GND") ))
		(setq p5 (polar p4  (dtor 270)  (cal "scale*asphalt2") ))
		(command "hatch" "ANSI38" (* 0.4 scale) "90" "" "N" p3 p4 p5 p2 "c" "")
		(setq p3 (polar p1  (dtor 0) (cal "scale*GND/2") ))
		(setq p3 (polar p3  (dtor 90) (cal "scale*asphalt2/2") ))
		(command "donut" 0 (* 0.08 boxscale) p3 "")
		(setq p4 (list (cal "scale*GND/2") yylay))
		(setq p5 (polar p4  (dtor 0 ) (cal "boxscale*GND")))
	       	(command "PLINE" p3 "w" "0" "0" p4 p5 "")
	       	(command "LAYER" "SET" "TEXT" "")
		(setq str (strcat " 기층 (아스콘#467) T=" (rtos (* asphalt2 1000) 2 0)))
		(command "TEXT" "J" "ML" p5 (* 0.15 tboxscale) "0" str)
		(setq yylay (cal "yylay-boxscale*0.3"))
		)
	)

)












































