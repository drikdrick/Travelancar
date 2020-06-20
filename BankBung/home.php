<!DOCTYPE html>
<html>
<head>
	<title>Bang Bunk</title>
	<link rel="stylesheet" type="text/css" href="css/style2.css">
	<link href="https://fonts.googleapis.com/css?family=Short+Stack&display=swap" rel="stylesheet">
</head>
<body style="background: url('image/bgs.jpg');">
	<?php 
	session_start();
	if($_SESSION['status']!="login"){
		header("location:login.php?pesan=belum_login");
	}
	?>
	<div class="container">
			<div class="header">
			<h2 style="font-family: 'Short Stack' , cursive ; font-size: 50px;">Selamat Datang di Bank Bung!</h2>
			<a href="logout.php">LOGOUT</a>
		</div>
		<div class="content1" style="background-image :url('image/atk.jpg');">
			<div class="gallery">
				  <a href="Saldo.php">
				    <img src="image/saldome.png" alt="Cek Saldo" width="300" height="300"></a>
				  <div class="desc">Cek Saldo</div>
			</div>
			<div class="gallery">
				  <a href="bayar.php">
				    <img src="image/pay.png" alt="Bayar" width="300" height="300"></a>
				  <div class="desc">Bayar</div>
			</div>
		</div>
	</div>
</body>
</html>