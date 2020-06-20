<!DOCTYPE html>
<html>
<head>
	<title>Lihat Data Pembayaran</title>
	<link rel="stylesheet" type="text/css" href="css/lihat.css">
	<link href="https://fonts.googleapis.com/css?family=Short+Stack&display=swap" rel="stylesheet">
</head>
<body>
	<div class="container">
		<div class="header">
			<h2 style="font-family: 'Short Stack' , cursive ; background-image: url('image/pay.png');">Daftar Pembayaran</h2>
		</div>
	<div class="tambah" style="background: lightblue; height: 230px;">
			
				<fieldset>
					<legend>Pembayaran anda</legend>
					<table border="1" style="background-color: white; text-align: center; width: 100%">
					<tr>
						<td><b />ID Transaksi</td>
						<td><b />Tagihan</td>
					</tr>
					<center>
						<h3>
				<?php
					include "connect.php";
					if(isset($_GET['nomor'])){
						$nomor = $_GET['nomor'];
						$data = $connectdb-> query("select * from transaksi where id_transaksi like  '".$nomor."'");
					// $view = $connectdb-> query("SELECT * FROM transaksi ORDER BY id_transaksi");
					while ($row = $data->fetch_array() )
					 		{
						?>
							<tr style="font-size: 18px;">
								<td>
									<?php echo $row['id_transaksi'];?>
								</td>
								<td>
									<?php echo $row['tagihan'];?>
								</td>
							</tr>
							<?php
									}
									$cek = mysqli_num_rows($data);
									if($cek < 1){
										header("location:bayar.php?pesan=gagal");
										}
								}
						?>
					</h3>
				</center>
				</table>
				
  				
  				<form action="home.php" method="">
						<br>
						<input type="checkbox" id="konf" name="yes" value="yes" style="margin-top: 3%">
		  				<label for="yes"> Anda sudah yakin ?</label><br>
		  				<br>
							
							<button onclick="bayar()" type="submit">Bayar</button>
							<script type="text/javascript">
								function bayar() {
									alert("Terimakasih telah melakukan pembayaran");
								}
							</script>
				</form>
  				
				</fieldset>
			
		</div>
	</div>
</body>
</html>