// JavaScript Document
var i = 1;
function changeColor() {
	i++;
	let table = document.getElementById("table");
	let tr = document.createElement('tr');
	let th = document.createElement('th');
	th.scope = 'id';
	th.textContent = i;
	let td2 = document.createElement('td');
	td2.textContent = 'x';
	let td3 = document.createElement('td');
	td3.textContent = 'x';
	tr.appendChild(th);
	tr.appendChild(td2);
	tr.appendChild(td3);
	table.appendChild(tr);
}