# COMPANY TRANSLATE

KISS implementation of company translator and taxonomy keeper.

The idea is to be able to approve certain keywords. In case there are no approved translations, a backup translator (e.g. Google translate) will suggest the translation (because something is better than nothing).

A user can propose an approval of a translation, which has to be processed by a person with correct permissions (AD based).

The application can also handle taxonomy, with explanation of the keyword.

Also, user can list all the approved keywords, see the explanations (if available) and approved translations.

## Setup

> TODO docker commands to docker compose

* run libretranslate

```
docker run -d --name libretranslate -p 5050:5000 -v D:\personal\docker-volumes\libretranslate:/home/libretranslate/ -e LT_LOAD_ONLY="cs,en" libretranslate/libretranslate
```
