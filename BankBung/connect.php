<?php
	//connect to database
	$connectdb = mysqli_connect("localhost","root","","bankbung");
	//checking
	if(mysqli_connect_errno()){
		echo "Silahkan Cek Data Base Kamu";
		exit;
	}
?>