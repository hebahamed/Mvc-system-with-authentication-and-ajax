function confirmDelete(id) {
    let res = confirm("Are you Sure >");
    if (res) {
        location.href = `delete/${id}`;
    }

}