<?php
$dsn = 'mysql:dbname=test;host=localhost';
$user = 'user';
$passwd = 'passowrd';
try {
  $dbh = new PDO($dbh, $user, $paswd);
} catch (PDOException $e) {
  echo "DB access ERROR: " . $e->getMessage() . "\n";
  exit();
}
?>
