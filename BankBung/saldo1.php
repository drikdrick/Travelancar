<!DOCTYPE html>
<html>
<head>
	<title>Saldo1</title>
	<link rel="stylesheet" type="text/css" href="css/saldo.css">
	<link href="https://fonts.googleapis.com/css?family=Pacifico&display=swap" rel="stylesheet">
	<script type = "text/javascript" >
		function preventBack(){window.history.forward();}
		setTimeout("preventBack()", 0);
		window.onunload=function(){null};
	</script>
</head>
<body background="image/bgs.jpg">
	<?php 
		session_start();
	?>
	<div class="container">
		<div class="header">
			<h2 style="font-family: 'Pacifico' , cursive; font-size: 50px;">Cek Jumlah Saldo</h2>
		</div>
		<div class="content">
			<div class="awl">
				<center><h2>Jumlah Saldo di rekening anda</h2></center>
				<br>
				<center>
					<h3>
				<?php
					//session_start();
					include "connect.php";
					if(isset($_GET['no_rek'])){
						$no_rek = $_GET['no_rek'];
						$data = $connectdb-> query("select * from user where no_rek like  '".$no_rek."'");
						$cek = mysqli_num_rows($data);
							if($cek > 0){
								while ($row = $data->fetch_array()){
						 		echo $row['saldo'];}
								$_SESSION['no_rek'] = $no_rek;
								$_SESSION['status'] = "sukses";
							}else{
								header("location:Saldo.php?pesan=gagal");
						}
					}
						// if($cek > 0){
						// 	header("location:Saldo.php?pesan=gagal");}
						// }	
						?>
						</h3>
				</center>
				<br>
				<br>
				<br>
				<br>
				<br>
				<br>
				<button onclick="location.href='Saldo.php'" class="btm">Kembali
				</button>
			</div>
		</form>
		</div>
	</div>	
</body>
