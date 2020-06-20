<!DOCTYPE html>
<html>
<head>
	<title>Saldo</title>
	<link rel="stylesheet" type="text/css" href="css/saldo.css">
	<link href="https://fonts.googleapis.com/css?family=Pacifico&display=swap" rel="stylesheet">
</head>
<body background="image/bgs.jpg">
	<div class="container">
		<div class="header">
			<h2 style="font-family: 'Pacifico' , cursive; font-size: 50px;">Cek Jumlah Saldo</h2>
		</div>
		<div class="content">
			<div class="awl">
			<form action="saldo1.php" method="get">
				<center><h2>Silahkan masukan nomor rekening anda</h2></center>
				<br>
				<input type="text" name="no_rek" class="saldo" placeholder="Nomor Rekening Anda">
				<br>
				<br>
				<button type="text" class="btm">Cek</button>

				<?php
					if(isset($_GET['pesan'])){
					if($_GET['pesan'] == "gagal"){
							echo "Nomor rekening yang anda masukkan salah!";
						}else if($_GET['pesan'] == "masukkan_no"){
						echo "Masukkan nomor rekening anda";
						}
					} ?>
					<br>
					<br>
				<br>
				
		</form>
				<button onclick="location.href='home.php'" type="text" class="btm">Home</button>
				<hr>
				</div>
		</div>
	</div>	
</body>
</html>