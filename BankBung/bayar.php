<!DOCTYPE html>
<html>
<head>
	<title>Bayar</title>
	<link rel="stylesheet" type="text/css" href="css/bayar.css">
	<link href="https://fonts.googleapis.com/css?family=Pacifico&display=swap" rel="stylesheet">
</head>
<body background="image/bgs.jpg">
	<div class="container">
		<div class="header">
			<h2 style="font-family: 'Pacifico' , cursive; font-size: 50px;">Bayar</h2>
		</div>
		<div class="content">
			<div class="mdl">
				<form action="Pembayaran.php" method="get">
						<br>
							<table>
								<tr>
									<td>
										<label>Nomor Pembayaran</label>
									</td>
									<td>:</td>
									<td>
										<input type="text" name="nomor" class="ktk_lgn">
									</td>
								</tr>
								<tr>
									<?php
											if(isset($_GET['pesan'])){
												if($_GET['pesan'] == "gagal"){
													echo "Nomor yang anda masukkan salah!!!";
											}
										} 
									?>
								</tr>
							</table>
							<button type="submit" name="submit" class="button">Cek</button>
				</form>
				
			</div>
		</div>
	</div>	
</body>
</html>