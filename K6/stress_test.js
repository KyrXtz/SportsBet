import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
    thresholds: {
        http_req_failed: ['rate<0.01'],
        http_req_duration: ['p(90) < 500', 'p(95) < 800', 'p(99.9) < 2000'],
    },
    stages: [
        { duration: '2m', target: 100 },
        { duration: '5m', target: 100 },
        { duration: '1m', target: 0 }
    ]
};

export default function () {
    const url = 'https://SportsBet.devgr.apinovi.com/api/v1/Feed/FeedHandler?contentType=xml';

    const params = {
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded',
        },
    };

    const payload = `rb_data=%3C%3Fxml+version%3D%271.0%27+encoding%3D%27UTF-8%27%3F%3E%0A%3Ckeep_alive
    +date_generated%3D%222023-04-26T09%3A06%3A04.498Z%22+pusher_id%3D%2240%22%2F%3E`;

    let res = http.post(url, payload, params);

    check(res, {
        'status is 200': (r) => r.status === 200,
        'status is not 400': (r) => r.status !== 400,
        'status is not 500': (r) => r.status !== 500,
    });
}
