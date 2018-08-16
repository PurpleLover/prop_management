function DateFormat(date) {
    const pad = val => val < 10 ? '0' + val : val;

    if (date !== null && date !== '') {
        let temp = new Date(date);
        return pad(temp.getDate()) + '/' + pad(temp.getMonth() + 1) + '/' + pad(temp.getFullYear());
    }
    return 'N/A';
}