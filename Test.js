import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
    vus: 1000,
    duration: '5s',
};

export default function () {
    const res = http.get('http://localhost:5000/Category');
    check(res, { 'status was 200': (r) => r.status == 200 });
}