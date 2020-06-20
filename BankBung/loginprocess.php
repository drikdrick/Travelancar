  
<?php
	session_start();
	include "connect.php";
	if (isset($_POST['submit'])){
			$username = $connectdb -> real_escape_string($_POST['username']);
		 	$password = $connectdb -> real_escape_string($_POST['password']);
			$query = $connectdb->query("SELECT * FROM user WHERE username='$username'and password='$password' ")or die(mySQli_error($connectdb));
			$cek = mysqli_num_rows($query);
			echo $cek;
			if($cek > 0){
					$_SESSION['username'] = $username;
					$_SESSION['status'] = "login";
					header("location:home.php");
				}else{
					header("location:login.php?pesan=gagal");
			}
		}

?>